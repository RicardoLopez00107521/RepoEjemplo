namespace AppointmentSystem.Models.DTOS
{
    public class GeneralResponseDTO
    {
        public string Message { get; set; }
        public object? Data { get; set; }

        public GeneralResponseDTO(String message, object data)
        {
            Message = message;
            Data = data;
        }
    }
}