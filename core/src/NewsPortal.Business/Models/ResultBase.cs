namespace NewsPortal.Business.Models
{
    public class ResultBase(IEnumerable<string>? errors)
    {
        public bool IsSuccessfull
        {
            get
            {
                return !Errors.Any();
            }
        }

        public IEnumerable<string> Errors { get; set; } = errors ?? [];
    }
}
