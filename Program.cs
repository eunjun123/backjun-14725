using System;
using System.Collections.Generic;
using System.Linq;
    public class Node
    {
        public Dictionary<string, Node> Childrun = new Dictionary<string, Node>();
        public int layer;
        public Node(int Layer)
        {
            layer = Layer;
        }
    }
    public class Trie
    {
        public Node rootNode = new Node(0);
        public void Insert(string[] stringList)
        {
            Node currentNode = rootNode;

            for (int i = 0; i < stringList.Length; i++)
            {
                if (!currentNode.Childrun.Keys.Contains(stringList[i]))
                {
                    var node = new Node(i + 1);
                    currentNode.Childrun.Add(stringList[i], node);
                }
                currentNode = currentNode.Childrun[stringList[i]];
            }
        }
        public void WriteNode(Node node)
        {
            if (node.Childrun.Count < 1)
            {
                return;
            }
            var childrenList = node.Childrun.Keys.OrderBy(x => x).ToArray();

            for (int i = 0; i < childrenList.Length; i++)
            {
                string contents = "";
                for (int k = 0; k < node.layer; k++)
                {
                    contents += "--";
                }
                contents += childrenList[i];
                Console.WriteLine(contents);
                WriteNode(node.Childrun[childrenList[i]]);
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();
            int cases = int.Parse(Console.ReadLine());
            for (int i = 0; i < cases; i++)
            {
                var input = Console.ReadLine().Split(' ');
                string[] s = new string[int.Parse(input[0])];
                Array.Copy(input, 1, s, 0, int.Parse(input[0]));
                trie.Insert(s);
            }
            trie.WriteNode(trie.rootNode);

        }
    }
