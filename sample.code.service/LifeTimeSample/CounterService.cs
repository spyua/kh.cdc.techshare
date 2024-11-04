namespace sample.code.service.LifeTimeSample
{
    public class CounterService
    {
        private int _count = 0;

        // 非線程安全方法，增加計數器並返回當前值
        public int IncrementAndGet()
        {
            _count++;
            return _count;
        }
    }
}
