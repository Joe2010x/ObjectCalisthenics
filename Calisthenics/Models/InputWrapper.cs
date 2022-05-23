namespace Calisthenics.Models
{
    public class InputWrapper
    {
        public string body;

        public InputWrapper(string input)
        {
            body = input;
        }

        public override string ToString()
        {
            return body.ToString();
        }
    }   
}