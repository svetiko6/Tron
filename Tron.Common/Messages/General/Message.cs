using System.Text;

namespace Tron.Common.Messages.General
{
    public class Message
    {
        public Header Header { get; private set; }

        private List<string> _segments;

        internal Message(Header header, List<string> segments)
        {
            Header = header;
            _segments = segments;
        }

        internal Message(string message)
        {
            string[] strings = message.Split('/');
            Header = (Header)int.Parse(strings[0]);
            _segments = [.. strings[1..]];
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();

            message.Append(Header.ToString());

            foreach (string segment in _segments)
            {
                message.Append($"/{segment}");
            }

            return message.ToString();
        }
    }
}
