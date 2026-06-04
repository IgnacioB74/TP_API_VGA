namespace Application.DTOs.UsuarioDTOs
{
    public class ChangePasswordDTO
    {
        public int UserId { get; set; }

        public string OldPassword { get; set; } = string.Empty;

        public string NewPassword { get; set; } = string.Empty;
    }
}