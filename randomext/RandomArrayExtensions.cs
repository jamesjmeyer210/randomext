namespace randomext;

public static class RandomArrayExtensions
{
    public static void NextArray<T>(this RandomType<T> self, T[] buffer, Func<RandomType<T>,T> generator)
    {
        for (var i = 0; i < buffer.Length; i++)
        {
            buffer[i] = generator.Invoke(self);
        }
    }

    public static T[] NextArray<T>(this RandomType<T> self, int size, Func<RandomType<T>,T> generator)
    {
        var n = new T[size];
        self.NextArray(n, generator);
        return n;
    }
}