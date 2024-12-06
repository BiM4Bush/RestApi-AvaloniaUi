namespace MVVMExampleApp.Backend.Services
{
    public class AddService : IAddService
    {
        public int Add(int firstInteger, int secondInteger)
        {
            return firstInteger + secondInteger;
        }
    }
}
