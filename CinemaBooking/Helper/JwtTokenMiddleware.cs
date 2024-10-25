namespace CinemaBooking.Helper
{
    public class JwtTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Kiểm tra xem có cookie "jwtToken" không
            if (context.Request.Cookies.ContainsKey("jwtToken"))
            {
                var token = context.Request.Cookies["jwtToken"];

                // Thêm token vào header "Authorization" nếu chưa có
                if (!string.IsNullOrEmpty(token) && !context.Request.Headers.ContainsKey("Authorization"))
                {
                    context.Request.Headers.Add("Authorization", $"Bearer {token}");
                        Console.WriteLine($"Authorization Header Added: Bearer {token}"); ;
                }
            }

            // Tiếp tục request tới middleware tiếp theo
            await _next(context);
        }
    }
}
