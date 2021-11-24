using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using System.IO;

namespace UT3Q2
{
    //Author: Pruthviraj Solanki (Knight)
    //Purpose: To do things mentioned in question 2-3-4-5
    class Program
    { 
        public class CNode
        {

            public string sColor;
            public int nextCost;
            public int prevCost;
            public LinkedListNode<CNode> link1;
            public int link1Cost;
            public LinkedListNode<CNode> link2;
            public int link2Cost;

            public CNode(string sColor, int nextCost, int prevCost, LinkedListNode<CNode> link1, int link1Cost, LinkedListNode<CNode> link2, int link2Cost)
            {
                this.sColor = sColor;
                this.nextCost = nextCost;
                this.prevCost = prevCost;
                this.link1 = link1;
                this.link1Cost = link1Cost;
                this.link2 = link2;
                this.link2Cost = link2Cost;

            }

        }
        static int[,] mCGraph = new int[,]
        {
            //             Red       blue        lightblue     Grey        Orange      Purple      Yellow      Green
            /*Red*/{       -1,        1,            -1,          5,          -1,          -1,        -1,         -1 },
            /*blue*/{      -1,       -1,             1,         -1,          -1,          -1,         8,         -1 },
            /*lightblue*/{ -1,        1,            -1,          0,          -1,          -1,        -1,         -1 },
            /*Grey*/{      -1,       -1,             0,         -1,           1,          -1,        -1,         -1 },
            /*Orange*/{    -1,       -1,            -1,         -1,          -1,           1,        -1,         -1 },
            /*Purple*/{    -1,       -1,            -1,         -1,          -1,          -1,         1,         -1 },
            /*Yellow*/{    -1,       -1,            -1,         -1,          -1,          -1,        -1,          6 },
            /*Green*/{     -1,       -1,            -1,         -1,          -1,          -1,        -1,         -1 }
        };

        //List graph
        static (int, int)[][] listGraph = new (int, int)[][]
        {
            /*Red*/ new (int, int)[] {(1, 1), (3, 5)},
            /*blue*/ new (int, int)[] {(2, 1), (6, 8)},
            /*lightblue*/ new (int, int)[] {(1, 1), (3, 0)},
            /*Grey*/ new (int, int)[] {(2, 0), (4, 1)},
            /*Orange*/ new (int, int)[] {(5, 1)},
            /*Purple*/ new (int, int)[] {(6,  1)},
            /*Yellow*/ new (int, int)[] {(7,  6)},
            /*Green*/ null
        };
        static List<Node> game = new List<Node>();
        static void DFS(int nIndex)
        {
            bool[] visited = new bool[listGraph.Length];
            DFSUtil(nIndex, ref visited);
        }
        static void DFSUtil(int v, ref bool[] visited)
        {
            visited[v] = true;

            if (v == 0)
            {
                Console.Write("Red-> ");
            }
            if (v == 1)
            {
                Console.Write("blue-> ");
            }
            if (v == 2)
            {
                Console.Write("lightblue-> ");
            }
            if (v == 3)
            {
                Console.Write("Grey-> ");
            }
            if (v == 4)
            {
                Console.Write("Orange-> ");
            }
            if (v == 5)
            {
                Console.Write("Purple-> ");
            }
            if (v == 6)
            {
                Console.Write("Yellow-> ");
            }
            if (v == 7)
            {
                Console.Write("Green ");
            }
            (int, int)[] colorList = listGraph[v];
            if (colorList != null)
            {
                foreach ((int, int) neighbor in colorList)
                {
                    if (!visited[neighbor.Item1])
                    {
                        DFSUtil(neighbor.Item1, ref visited);
                    }
                }
            }
        }
        public class Node : IComparable<Node>
        {
            public int nState;
            public Node(int nState)
            {
                this.nState = nState;
                this.minCostToStart = int.MaxValue;
            }
            public List<Edge> edges = new List<Edge>();
            public int minCostToStart;
            public Node nearestToStart;
            public bool visited;
            public void AddEdge(int cost, Node connection)
            {
                Edge e = new Edge(cost, connection);
                edges.Add(e);
            }
            public int CompareTo(Node n)
            {
                return this.minCostToStart.CompareTo(n.minCostToStart);
            }
        }
        public class Edge : IComparable<Edge>
        {
            public int cost;
            public Node connectedNode;
            public Edge(int cost, Node connectedNode)
            {
                this.cost = cost;
                this.connectedNode = connectedNode;
            }
            public int CompareTo(Edge e)
            {
                return this.cost.CompareTo(e.cost);
            }
        }
        static public List<Node> GetShortestPathDijkstra()
        {
            DijstraSearch();
            List<Node> shortestPath = new List<Node>();
            shortestPath.Add(game[5]);
            BuildShortestPath(shortestPath, game[5]);
            shortestPath.Reverse();
            return (shortestPath);
        }
        static public void BuildShortestPath(List<Node> list, Node node)
        {
            if (node.nearestToStart == null)
            {
                return;
            }
            list.Add(node.nearestToStart);
            BuildShortestPath(list, node.nearestToStart);
        }
        static public void DijstraSearch()
        {
            Node start = game[2];
            start.minCostToStart = 0;
            List<Node> prioQueue = new List<Node>();
            prioQueue.Add(start);
            do
            {
                prioQueue.Sort();
                prioQueue = prioQueue.OrderBy(delegate (Node n) { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((Node n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => n.minCostToStart).ToList();
                prioQueue = prioQueue.OrderBy(n => n.minCostToStart).ToList();
                Node node = prioQueue.First();
                prioQueue.Remove(node);
                foreach (Edge cnn in node.edges)
                {
                    Node childNode = cnn.connectedNode;
                    if (childNode.visited)
                    {
                        continue;
                    }
                    if (childNode.minCostToStart == int.MaxValue || node.minCostToStart + cnn.cost < childNode.minCostToStart)
                    {
                        childNode.minCostToStart = node.minCostToStart + cnn.cost;
                        childNode.nearestToStart = node;
                        if (!prioQueue.Contains(childNode))
                        {
                            prioQueue.Add(childNode);
                        }
                    }
                }
                node.visited = true;
                if (node == game[5])
                {
                    return;
                }
            } while (prioQueue.Any());
        }
        static void Main(string[] args)
        {
            Random rand = new Random();
            Node node;
            int i = 0;
            DFS(0);
            for (i = 0; i < listGraph.Length; ++i)
            {
                node = new Node(i);
                game.Add(node);
            }
            for (i = 0; i < listGraph.Length; ++i)
            {
                (int, int)[] colorList = listGraph[i];
                for (int cCntr = 0; colorList != null && cCntr < colorList.Length; ++cCntr)
                {
                    game[i].AddEdge(colorList[cCntr].Item2, game[colorList[cCntr].Item1]);
                }
                game[i].edges.Sort();
            }
            //creating the linked list
            LinkedList<LinkedListNode<CNode>> linkedList = new LinkedList<LinkedListNode<CNode>>();
            CNode redCNode = new CNode(null, -1, -1, null, -1, null, -1);
            CNode blueCNode = new CNode(null, -1, -1, null, -1, null, -1);
            CNode lightblueCNode = new CNode(null, -1, -1, null, -1, null, -1);
            CNode greyCNode = new CNode(null, -1, -1, null, -1, null, -1);
            CNode orangeCNode = new CNode(null, -1, -1, null, -1, null, -1);
            CNode purpleCNode = new CNode(null, -1, -1, null, -1, null, -1);
            CNode yellowCNode = new CNode(null, -1, -1, null, -1, null, -1);
            CNode greenCNode = new CNode(null, -1, -1, null, -1, null, -1);
            //storing the colors
            redCNode.sColor = "red";
            blueCNode.sColor = "blue";
            lightblueCNode.sColor = "lightblue";
            greyCNode.sColor = "grey";
            orangeCNode.sColor = "orange";
            purpleCNode.sColor = "purple";
            yellowCNode.sColor = "yellow";
            greenCNode.sColor = "green";
            //storting the costs
            redCNode.nextCost = 1;
            redCNode.prevCost = 5;
            blueCNode.nextCost = 8;
            blueCNode.prevCost = 1;
            lightblueCNode.nextCost = 1;
            lightblueCNode.prevCost = 0;
            greyCNode.nextCost = 1;
            greyCNode.prevCost = 0;
            orangeCNode.nextCost = 1;
            orangeCNode.prevCost = -1;
            purpleCNode.nextCost = 1;
            purpleCNode.prevCost = -1;
            yellowCNode.nextCost = 6;
            yellowCNode.prevCost = 1;
            
            LinkedListNode<CNode> redLinkNode = new LinkedListNode<CNode>(redCNode);
            LinkedListNode<CNode> blueLinkNode = new LinkedListNode<CNode>(blueCNode);
            LinkedListNode<CNode> lightblueLinkNode = new LinkedListNode<CNode>(lightblueCNode);
            LinkedListNode<CNode> greyLinkNode = new LinkedListNode<CNode>(greyCNode);
            LinkedListNode<CNode> orangeLinkNode = new LinkedListNode<CNode>(orangeCNode);
            LinkedListNode<CNode> purpleLinkNode = new LinkedListNode<CNode>(purpleCNode);
            LinkedListNode<CNode> yellowLinkNode = new LinkedListNode<CNode>(yellowCNode);
            LinkedListNode<CNode> greenLinkNode = new LinkedListNode<CNode>(greenCNode);

            lightblueCNode.link1 = blueLinkNode;
            lightblueCNode.link1Cost = 1;
            lightblueCNode.link2 = greyLinkNode;
            lightblueCNode.link2Cost = 0;
            blueCNode.link1 = lightblueLinkNode;
            blueCNode.link1Cost = 1;
            greyCNode.link1 = lightblueLinkNode;
            greyCNode.link1Cost = 0;

            linkedList.AddLast(redLinkNode);
            linkedList.AddLast(blueLinkNode);
            linkedList.AddLast(lightblueLinkNode);
            linkedList.AddLast(greyLinkNode);
            linkedList.AddLast(orangeLinkNode);
            linkedList.AddLast(purpleLinkNode);
            linkedList.AddLast(yellowLinkNode);
            linkedList.AddLast(greenLinkNode);
        }
    }
}