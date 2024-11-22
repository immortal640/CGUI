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

    public class CRYPTOGRAPHY
    {
        private byte[] IV =
{
        0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
        0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
        };

        private byte[] DeriveKeyFromPassword(string password)
        {
            var emptySalt = Array.Empty<byte>();
            var iterations = 1000;
            var desiredKeyLength = 16; // 16 bytes equal 128 bits.
            var hashMethod = HashAlgorithmName.SHA384;
            return Rfc2898DeriveBytes.Pbkdf2(Encoding.Unicode.GetBytes(password),
                                             emptySalt,
                                             iterations,
                                             hashMethod,
                                             desiredKeyLength);
        }

        public async Task<byte[]> EncryptAsync(string clearText, string passphrase)
        {
            using Aes aes = Aes.Create();
            aes.Key = DeriveKeyFromPassword(passphrase);
            aes.IV = IV;
            using MemoryStream output = new();
            using CryptoStream cryptoStream = new(output, aes.CreateEncryptor(), CryptoStreamMode.Write);
            await cryptoStream.WriteAsync(Encoding.Unicode.GetBytes(clearText));
            await cryptoStream.FlushFinalBlockAsync();
            return output.ToArray();
        }

        public async Task<string> DecryptAsync(byte[] encrypted, string passphrase)
        {
            using Aes aes = Aes.Create();
            aes.Key = DeriveKeyFromPassword(passphrase);
            aes.IV = IV;
            using MemoryStream input = new(encrypted);
            using CryptoStream cryptoStream = new(input, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using MemoryStream output = new();
            await cryptoStream.CopyToAsync(output);
            return Encoding.Unicode.GetString(output.ToArray());
        }
    }

    public class USER
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid GUID { get; private set; }
        public string PasscodeSHA256 { get; set; }
        public MESSAGE[] MessageFeed { get; set; }
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
                Console.SetCursorPosition(1, Console.BufferHeight - 2);
                MessageFeed[i].Endl = true;
                MessageFeed[i].Display();
                if (ActionFeed[i].ID != 0)
                {
                    Console.WriteLine($"Acttion:{ActionFeed[i].Name} {ActionFeed[i].GUID.ToString()}");
                }
                string? response = "";
                MESSAGE.Info("Type 'next' to display next message: ", 10, false);
                while (response.ToLower() != "next")
                    response = Console.ReadLine();
            }
        }

        public void SendMessage(USER sender, string message, ACTION? action = null)
        {
            MESSAGE messageM = new MESSAGE();
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

            List<MESSAGE> messageFeed = MessageFeed.ToList();
            messageFeed.Add(messageM);
            MessageFeed = messageFeed.ToArray();
        }
        public void SendMessage(USER sender, MESSAGE message, ACTION? action = null)
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

            List<MESSAGE> messageFeed = MessageFeed.ToList();
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
                MESSAGE.CritErr("Access denied!");
                LOG.CritErr($"Access denied! [{user.Name}|{user.GUID.ToString()}]");
                return;
            }
            MESSAGE authMsg = new MESSAGE()
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
