using System.Collections.Generic;

namespace Cidades.Domain.Containers
{
    public class RequestResult<T>
    {
        public RequestResult()
        {
            Messages = new List<string>();
        }

        public RequestResult(int status, T data)
            : this()
        {
            Status = status;
            Data = data;
        }

        public RequestResult(int status, List<string> messages)
            : this()
        {
            Status = status;

            if (messages != null)
            {
                foreach (var message in messages)
                {
                    Messages.Add(message);
                }
            }
        }

        public RequestResult(int status, T data, List<string> messages)
            : this()
        {
            Status = status;
            Data = data;

            if (messages != null)
            {
                foreach (var message in messages)
                {
                    Messages.Add(message);
                }
            }
        }

        public int Status { get; set; }

        public T Data { get; set; }

        public List<string> Messages { get; set; }
    }
}
