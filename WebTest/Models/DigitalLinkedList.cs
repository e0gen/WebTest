using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest
{
    public class DigitalLinkedList : LinkedList<int>
    {
        public DigitalLinkedList(int input)
        {
            var array = input.ToString().Select(o => Convert.ToInt32(o) - 48);
            foreach (var value in array)
                this.AddFirst(value);
        }

        public DigitalLinkedList(int[] reversedArray)
        {
            foreach (var value in reversedArray)
                this.AddLast(value);
        }

        public static DigitalLinkedList operator +(DigitalLinkedList b, DigitalLinkedList c)
        {
            return new DigitalLinkedList((b.ToInt32() + c.ToInt32()));
        }

        public int ToInt32()
        {
            int result = 0;
            int order = 1;
            for (var node = this.First; node != null; node = node.Next)
            {
                result += node.Value * order;
                order *= 10;
            }
            return result;
        }
    }
}
