using System;

namespace PriorityQueue
{
    public class PQE
    {
        public string data; //data
        public int priority;//priority
        public PQE next;
        public PQE()
        { }
        public PQE(string data, int priority)
        {
            this.data = data;
            this.priority = priority;
        }
    }
    public class PriorityQueue //A PQ where highest priority will always be at the head
    {

        public static string peek(PQE head)
        {
            return head.data;
        }

        public static PQE dequeue(PQE head)
        {
            PQE temp = head;
            (head) = (head).next;
            return head;
        }

        public static PQE enqueue(PQE head, string d, int p)
        {
            PQE start = (head);
            PQE temp = new PQE(d, p);
            if ((head).priority > p)
            {
                temp.next = head;
                (head) = temp;
            }
            else
            {
                while (start.next != null && start.next.priority < p)
                {
                    start = start.next;
                }
                temp.next = start.next;
                start.next = temp;
            }
            return head;
        }

        public static int isEmpty(PQE head)
        {
            return ((head) == null) ? 1 : 0;
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            PQE pqe = new PQE();
            pqe = PriorityQueue.enqueue(pqe,"1", 1);
            
            pqe = PriorityQueue.enqueue(pqe, "9", 2); 
            pqe = PriorityQueue.enqueue(pqe, "7", 3);
            pqe =PriorityQueue.enqueue(pqe, "3", 0);

            while (PriorityQueue.isEmpty(pqe) == 0)
            {
                Console.Write("{0} ", PriorityQueue.peek(pqe));
                pqe = PriorityQueue.dequeue(pqe);
            }
        }
    }
}
