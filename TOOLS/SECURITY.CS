using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace TOOLS
{
    class SECURITY
    {
        public static USER[] USERs { get; set; }
        public static LEVEL[] LEVELs { get; set; }
    }

    public class Cryptography
    {
        public static string Encrypt(string txt, string key)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(txt);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                using (TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDESCryptoServiceProvider.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results);
                }
            }
        }
        public static string Decrypt(string txt, string key, string? defaultValue)
        {
            try
            {
                byte[] data = Convert.FromBase64String(txt);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    using (TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripleDESCryptoServiceProvider.CreateDecryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        return UTF8Encoding.UTF8.GetString(results);
                    }
                }
            }
            catch
            {
                return defaultValue;
            }
        }
    }

    public class USER
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid GUID { get; private set; }
        public string PasscodeSHA256 { get; set; }
        public Message[] MessageFeed { get; set; }
        public ACTION[] ActionFeed { get; set; }

        public void Initialize()
        {
            GUID = Guid.NewGuid();

            List<USER> users = SECURITY.USERs.ToList();
            users.Add(this);
            SECURITY.USERs = users.ToArray();
        }

        public void Tick()
        {
            //
        }

        public void ReceveMessageFeed()
        {
            for (int i = 0; i < MessageFeed.Length; i++)
            {
                System.Console.SetCursorPosition(1, System.Console.BufferHeight - 2);
                MessageFeed[i].Endl = true;
                MessageFeed[i].Display();
                if (ActionFeed[i].ID != 0)
                {
                    System.Console.WriteLine($"Acttion:{ActionFeed[i].Name} {ActionFeed[i].GUID.ToString()}");
                }
                string? response = "";
                Message.Info("Type 'next' to display next message: ", 10, false);
                while (response.ToLower() != "next")
                    response = System.Console.ReadLine();
            }
        }

        public void SendMessage(USER sender, string message, ACTION? action = null)
        {
            Message messageM = new Message();
            messageM.Text = message;
            if (sender.Name.Length <= 10)
                messageM.Title = sender.Name;
            else
            {
                string title = sender.Name;
                title.Remove(title.Length - 3, 2);
                title += "..";
                messageM.Title = title;
            }
            messageM.TitleColor = ConsoleColor.DarkCyan;

            if (action ==  null)
            {
                action = new ACTION(this)
                {
                    Name = "NONE",
                    Description = "There's nothing to do",
                    ID = 0
                };
            }

            List<ACTION> actionFeed = ActionFeed.ToList();
            actionFeed.Add(action);
            ActionFeed = actionFeed.ToArray();

            List<Message> messageFeed = MessageFeed.ToList();
            messageFeed.Add(messageM);
            MessageFeed = messageFeed.ToArray();
        }
        public void SendMessage(USER sender, Message message, ACTION? action = null)
        {
            if (action == null)
            {
                action = new ACTION(this)
                {
                    Name = "NONE",
                    Description = "There's nothing to do",
                    ID = 0
                };
            }

            List<ACTION> actionFeed = ActionFeed.ToList();
            actionFeed.Add(action);
            ActionFeed = actionFeed.ToArray();

            List<Message> messageFeed = MessageFeed.ToList();
            messageFeed.Add(message);
            MessageFeed = messageFeed.ToArray();
        }
    }

    public class LEVEL
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LevelID { get; set; }
        public Guid GUID { get; private set; }
        public USER[] Users { get; set; }
        public USER[] UsersTMP { get; set; }

        public void Initialize()
        {
            GUID = Guid.NewGuid();
            List<USER> LUsersTMP = new List<USER>();
            UsersTMP = LUsersTMP.ToArray();
        }

        public void GainAcces(USER user, USER authenticator, bool temporary = true)
        {
            if (!Users.Contains(authenticator))
            {
                Message.CritErr("Access denied!");
                LOG.CritErr($"Access denied! [{user.Name}|{user.GUID.ToString()}]");
                return;
            }
            Message authMsg = new Message()
            {
                Text = $"Authentication required: U:[{user.Name}|{user.GUID.ToString()}] => L:[{Name}|{GUID.ToString()}]",
                Title = "AUTH",
                TitleColor = ConsoleColor.DarkYellow,
                Offset = 10,
                Endl = true
            };
            ACTION authAction = new ACTION(authenticator)
            {
                Name = "UserAccessLevelupAcception",
                Description = "The User " + user.Name + " wants to move to the " + Name + " level."
            };
            authenticator.SendMessage(user, authMsg, authAction);
        }
    }

    public class ACTION
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid GUID { get; private set; }
        /// <summary>
        /// This is the action-id.
        /// <c>0</c> -> No action
        /// <c>1</c> -> <c>USER</c> authentication
        /// <c>2</c> -> N/A
        /// <c>3</c> -> N/A
        /// <c>4</c> -> N/A
        /// <c>5</c> -> N/A
        /// <c>6</c> -> N/A
        /// <c>7</c> -> N/A
        /// <c>8</c> -> N/A
        /// <c>9</c> -> N/A
        ///  More actions will be added later.
        /// </summary>
        public long ID { get; set; }
        public bool Completed { get; private set; }
        public USER TaskedUser { get; private set; }

        public ACTION(USER taskedUser)
        {
            TaskedUser = taskedUser;
        }

        public void Complete(USER taskedUser, string? passcode)
        {
            if (Completed)
                return;
            if (taskedUser == TaskedUser)
            {
                switch (ID)
                {
                    case 0:
                        Completed = true;
                        break;
                    case 1:
                        if (SHA512.Create(passcode).Equals(taskedUser.PasscodeSHA256))
                        {
                            Completed = true;
                        }
                        break;
                }
            }
        }
    }
}
