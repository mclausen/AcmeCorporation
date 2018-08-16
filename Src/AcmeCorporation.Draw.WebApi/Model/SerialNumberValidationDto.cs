namespace AcmeCorporation.Draw.WebApi.Model
{
    public class SerialNumberValidationDto
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        private SerialNumberValidationDto(){}
        
        public static SerialNumberValidationDto Success()
        {
            return new SerialNumberValidationDto()
            {
                IsValid = true,
                ErrorMessage = string.Empty
            };
        }
        
        public static SerialNumberValidationDto FailedWithError(string error)
        {
            return new SerialNumberValidationDto()
            {
                IsValid = false,
                ErrorMessage = error
            };
        }
    }
}