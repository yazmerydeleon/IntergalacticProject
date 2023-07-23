using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntegerTree : MonoBehaviour
{
    private IntegerNode root;

    public IntegerTree()
    {
        root = null;
    }

    public void Insert(int parentVal, int childVal)
    {

    }

    
    class IntegerNode
    {
        public int value;

        public List<IntegerNode> children = new List<IntegerNode>();

        public IntegerNode(int value)
        { 
            this.value = value;
        }
    }



}
