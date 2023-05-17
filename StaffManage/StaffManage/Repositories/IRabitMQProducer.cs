namespace StaffManage.Repositories
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage<T>(T message);
    }
}
