namespace POSwebApi.Dtos
{
    public class UserDTO
    {
        public int id { get; set; } 
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
    }
}
