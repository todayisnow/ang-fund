using System;

namespace LingTest
{
    internal class Shopper
    {

        public Shopper(ICart c)
        {
            Console.WriteLine(c.GetType());
        }
        internal void Charge()
        {
            //throw new NotImplementedException();
        }
    }

    public interface ICart
    {
    }
    public class Cart:ICart
    {

    }
}