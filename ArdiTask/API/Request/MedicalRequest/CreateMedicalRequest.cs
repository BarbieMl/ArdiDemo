namespace API.Request.CustomerRequest
{
    public record CreateMedicalRequest(
        string Citizenship, 
        string IdNumber, 
        DateOnly DateOfBirth,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Email,
        //to do: GenderEnum
        string Gender,
        string Adress,
        DateTime FromDate,
        DateTime ToDate);
}
