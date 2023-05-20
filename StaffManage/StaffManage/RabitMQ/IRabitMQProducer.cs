using StaffManage.Models;

namespace StaffManage.RabitMQ
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage(CanBoNghienCuu canBo);
    }
}
