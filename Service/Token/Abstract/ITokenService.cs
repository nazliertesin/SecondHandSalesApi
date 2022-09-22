using Base;

namespace Service
{
    public interface ITokenService
    {
        BaseResponse<TokenResponse> GenerateToken(TokenRequest tokenRequest);
    }
}
