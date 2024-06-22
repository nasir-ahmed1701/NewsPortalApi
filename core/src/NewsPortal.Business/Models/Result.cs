namespace NewsPortal.Business.Models
{
    public class Result<T>(IEnumerable<string>? errors, T? data)
    {
        public bool IsSuccessfull
        {
            get
            {
                return !Errors.Any();
            }
        }

        public IEnumerable<string> Errors { get; set; } = errors ?? Enumerable.Empty<string>();

        public T? Data { get; set; } = data;
    }
}
