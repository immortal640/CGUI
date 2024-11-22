using TOOLS;

namespace CGUI
{
    public class MENU
    {
        public object[] Contents { get; set; } = new object[0];
        public string title { get; set; } = "Menu";

        public void Tick(ConsoleKey key)
        {
            Console.Title = title;
            for (int i = 0; i < Contents.Length; i++)
            {
                if (Contents[i] is FIELD field)
                    field.Tick();
                if (Contents[i] is INTERACTION interaction)
                    interaction.Tick();
                if (Contents[i] is TEXT text)
                    text.Tick();
                if (Contents[i] is BUTTON button)
                    button.Tick();
                if (Contents[i] is INPUT input)
                    input.Tick(key);
            }
        }

        public void AddItem(object item)
        {
            List<object> contentsL = Contents.ToList<object>();
            if (item is FIELD field)
                contentsL.Add(field);
            if (item is INTERACTION interaction)
                contentsL.Add(interaction);
            if (item is TEXT text)
                contentsL.Add(text);
            if (item is BUTTON button)
                contentsL.Add(button);
            if (item is INPUT input)
                contentsL.Add(input);
        }
        public void RemoveItem(object item)
        {
        }
    }
}
