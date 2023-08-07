namespace BlazorCF.Domain
{
    public class User
    {
        public string Login { get; set; }
        public string Avatar_Url { get; set; }
        public string Fullname { get; set; }
        public string Company { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public int Repos { get; set; }
        public string Token { get; set; }
    }
}
