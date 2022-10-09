namespace Application.Features.UserOperationClaims.Dtos
{
    public class UserOperationClaimGetByIdDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string OperationClaimId { get; set; }
    }
}
