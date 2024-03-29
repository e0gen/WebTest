﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest
{
    public class DigitalLinkedList : LinkedList<int>
    {
        public DigitalLinkedList()
        {
        }
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

        public static DigitalLinkedList operator +(DigitalLinkedList a, DigitalLinkedList b)
        {
            //Θ(n)
            var c = new DigitalLinkedList();

            if (a.Count < b.Count)
            {
                var x = a;
                a = b;
                b = x;
            }

            int addition = 0;
            var nodeB = b.First;
            for (var nodeA = a.First; nodeA != null; nodeA = nodeA.Next)
            {
                if (nodeB != null)
                {
                    var sum = nodeA.Value + nodeB.Value + addition;

                    if (sum > 10)
                    {
                        addition = sum / 10;
                        c.AddLast(sum % 10);
                    }
                    else
                    {
                        addition = 0;
                        c.AddLast(sum);
                    }
                    nodeB = nodeB.Next;
                }
                else
                    c.AddLast(nodeA.Value);
            }
            if(addition > 0) c.AddLast(addition);
            return c;
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
