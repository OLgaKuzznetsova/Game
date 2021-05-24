using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using JetBrains.Annotations;
using UnityEngine;

public class MovingPathFinder : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] points;
    public Dictionary<string, int> dictionary;
    public Graph graph;
    //public string path;
    public int number;
    public int[] indexArray; 
    public  int i = 0;
    private bool CanDo = true;
    public Player player;
    public GameObject virus;
    public void Start()
    {
        
        gameObject.transform.position = new Vector3(points[4].position.x, points[4].position.y, 0);
        Main();
    }

    public void Main()
    {
        graph = new Graph();
        for (var v = 65; v < 78; v++)
        {
            
            graph.AddNode(Convert.ToChar(v).ToString());
        }
        dictionary = new Dictionary<string, int>();
        dictionary.Add("A", 0);
        dictionary.Add("B", 1);
        dictionary.Add("C", 2);
        dictionary.Add("D", 3);
        dictionary.Add("E", 4);
        dictionary.Add("F", 5);
        dictionary.Add("G", 6);
        dictionary.Add("H", 7);
        dictionary.Add("I", 8);
        dictionary.Add("J", 9);
        dictionary.Add("K", 10);
        dictionary.Add("L", 11);
        dictionary.Add("M", 12);
        graph.AddEdge("A", "B", 10);
        graph.AddEdge("A", "L", 8);
        graph.AddEdge("A", "K", 8);
        graph.AddEdge("A", "G", 5);
        graph.AddEdge("A", "D", 10);
        graph.AddEdge("C", "I", 5);
        graph.AddEdge("C", "M", 5);
        graph.AddEdge("C", "B", 10);
        graph.AddEdge("I", "C", 5);
        graph.AddEdge("I", "M", 5);
        graph.AddEdge("M", "I", 5);
        graph.AddEdge("M", "C", 8);
        graph.AddEdge("M", "H", 5);
        graph.AddEdge("M", "B", 8);
        graph.AddEdge("B", "C", 10);
        graph.AddEdge("B", "M", 8);
        graph.AddEdge("B", "H", 5);
        graph.AddEdge("B", "L", 8);
        graph.AddEdge("B", "A", 10);
        graph.AddEdge("H", "B", 5);
        graph.AddEdge("H", "M", 5);
        graph.AddEdge("H", "L", 5);
        graph.AddEdge("L", "H", 5);
        graph.AddEdge("L", "B", 8);
        graph.AddEdge("L", "G", 5);
        graph.AddEdge("L", "A", 8);
        graph.AddEdge("G", "A", 5);
        graph.AddEdge("G", "L", 5);
        graph.AddEdge("G", "K", 5);
        graph.AddEdge("K", "A", 8);
        graph.AddEdge("K", "G", 5);
        graph.AddEdge("K", "F", 5);
        graph.AddEdge("K", "D", 8);
        graph.AddEdge("D", "A", 10);
        graph.AddEdge("D", "K", 8);
        graph.AddEdge("D", "F", 5);
        graph.AddEdge("D", "J", 8);
        graph.AddEdge("D", "E", 10);
        graph.AddEdge("F", "D", 5);
        graph.AddEdge("F", "J", 5);
        graph.AddEdge("F", "K", 5);
        graph.AddEdge("J", "F", 5);
        graph.AddEdge("J", "D", 8);
        graph.AddEdge("J", "E", 8);
        graph.AddEdge("E", "J", 8);
        graph.AddEdge("E", "D", 10);
       
      

    }

    public void Path(string a, string b)
    {
        var dijkstra = new Dijkstra(graph);
        var path =  dijkstra.FindShortestPath(a, b);
        print(path);
        print("asd");
        indexArray = new int[path.Length];
        for (var e = 0; e < path.Length; e++)
        {
            indexArray[e] = dictionary[path[e].ToString()];
        }
        
    }

    public Transform FindPosition(Vector3 position)
    {
        print(3);
        //var position = player.transform.position;
        Transform point = new RectTransform();
        var minDistance = double.MaxValue;
        for (var e = 0; e < points.Length; e++)
        {
            var katet1 = Math.Pow(Math.Abs(points[e].position.x - position.x), 2);
            var katet2 = Math.Pow(Math.Abs(points[e].position.y - position.y), 2);
            if (Math.Sqrt(katet1 + katet2) < minDistance)
            {
                minDistance = Math.Sqrt(katet1 + katet2);
                point = points[e];
                number = e;
            }
        }
        print(4);
        return point;
    }
    
    public void TimerStep()
    {
        var playerPosition = FindPosition(player.transform.position);
        var point1 = dictionary.Where(x => x.Value == number).FirstOrDefault().Key;
        var virusPosition = FindPosition(gameObject.transform.position);
        var point2 = dictionary.Where(x => x.Value == number).FirstOrDefault().Key;
        Path(point2, point1);
    }
    void Update()
    {
        TimerStep();
        if (CanDo)
            transform.position = Vector3.MoveTowards(transform.position, points[indexArray[i]].position, speed * Time.deltaTime);
        if (transform.position == points[indexArray[i]].position)
        {
            if (i < indexArray.Length -  1)
                i++;
            else
                i = 0;
        }
    }
    
    public class GraphEdge
    {
        public GraphNode ConnectedNode { get; }
        public int EdgeWeight { get; }

        public GraphEdge(GraphNode connectedNode, int weight)
        {
            ConnectedNode = connectedNode;
            EdgeWeight = weight;
        }
    }

    public class GraphNode
    {
        public string Name { get; }

        public List<GraphEdge> Edges { get; }

        public GraphNode(string nodeName)
        {
            Name = nodeName;
            Edges = new List<GraphEdge>();
        }

        public void AddEdge(GraphEdge newEdge)
        {
            Edges.Add(newEdge);
        }

        public void AddEdge(GraphNode node, int edgeWeight)
        {
            AddEdge(new GraphEdge(node, edgeWeight));
        }

        public override string ToString() => Name;
    }

    public class Graph
    {
        public List<GraphNode> Nodes { get; }

        public Graph() 
            => Nodes = new List<GraphNode>();

        public void AddNode(string nodeName) 
            => Nodes.Add(new GraphNode(nodeName));

        public GraphNode FindNode(string nodeName)
            => Nodes.FirstOrDefault(v => v.Name.Equals(nodeName));

        public void AddEdge(string firstName, string secondName, int weight)
        {
            var v1 = FindNode(firstName);
            var v2 = FindNode(secondName);
            if (v2 != null && v1 != null)
            {
                v1.AddEdge(v2, weight);
                v2.AddEdge(v1, weight);
            }
        }
    }

    public class GraphNodeInfo
    {
        public GraphNode Node { get; set; }

        public bool IsUnvisited { get; set; }

        public int EdgesWeightSum { get; set; }

        public GraphNode PreviousNode { get; set; }

        public GraphNodeInfo(GraphNode node)
        {
            Node = node;
            IsUnvisited = true;
            EdgesWeightSum = int.MaxValue;
            PreviousNode = null;
        }
    }

    public class Dijkstra
    {
        Graph graph;

        List<GraphNodeInfo> information;

        public Dijkstra(Graph graph)
        {
            this.graph = graph;
        }

        void InitInfo()
        {
            information = new List<GraphNodeInfo>();
            foreach (var v in graph.Nodes)
            {
                information.Add(new GraphNodeInfo(v));
            }
        }

        GraphNodeInfo GetNodeInfo(GraphNode v) 
            => information.FirstOrDefault(i => i.Node.Equals(v));

        public GraphNodeInfo FindUnvisitedNodeWithMinSum()
        {
            var minValue = int.MaxValue;
            GraphNodeInfo minNodeInfo = null;
            foreach (var i in information.Where(i => i.IsUnvisited && i.EdgesWeightSum < minValue))
            {
                minNodeInfo = i;
                minValue = i.EdgesWeightSum;
            }

            return minNodeInfo;
        }

        public string FindShortestPath(string startName, string finishName) 
            => FindShortestPath(graph.FindNode(startName), graph.FindNode(finishName));


        public string FindShortestPath(GraphNode startNode, GraphNode finishNode)
        {
            InitInfo();
            var first = GetNodeInfo(startNode);
            first.EdgesWeightSum = 0;
            while (true)
            {
                var current = FindUnvisitedNodeWithMinSum();
                if (current == null)
                {
                    break;
                }

                SetSumToNextNode(current);
            }

            return GetPath(startNode, finishNode);
        }


        void SetSumToNextNode(GraphNodeInfo info)
        {
            info.IsUnvisited = false;
            foreach (var e in info.Node.Edges)
            {
                var nextInfo = GetNodeInfo(e.ConnectedNode);
                var sum = info.EdgesWeightSum + e.EdgeWeight;
                if (sum < nextInfo.EdgesWeightSum)
                {
                    nextInfo.EdgesWeightSum = sum;
                    nextInfo.PreviousNode = info.Node;
                }
            }
        }

        string GetPath(GraphNode startNode, GraphNode endNode)
        {
            var path = endNode.ToString();
            while (startNode != endNode)
            {
                endNode = GetNodeInfo(endNode).PreviousNode;
                path = endNode + path;
            }

            return path;
        }
    }
}