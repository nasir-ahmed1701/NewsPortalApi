namespace NewsPortal.Business.Models
{
    public class Result<T>(IEnumerable<string>? errors, T? data) : ResultBase(errors)
    {
        public T? Data { get; set; } = data;
    }
}
