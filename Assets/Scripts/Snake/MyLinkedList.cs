using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLinkedList<T> 
{
    public MyNode<T> head;
    int count;

    public MyNode<T> first;

    public MyNode<T> AddNodeFirst(T _value)
    {
        MyNode<T> node = new MyNode<T>(_value);
        node.next = head;
        head = node;
        first = node;
        count++;
        return node;
    }

    public MyNode<T> AddNodeLast(T _value)
    {
        if (head == null)
        {
            return AddNodeFirst(_value);
        }
        MyNode<T> runner = head;
        while (runner != null)
        {
            if (runner.next == null)
            {
                break;
            }
            runner = runner.next;
              
        }
        MyNode<T> newNode = new MyNode<T>(_value);
        runner.next = newNode;
        count++;
        return newNode;
    }

    public MyLinkedList()
    {
        head = null;
        count = 0;
    }
}

public class MyNode<T>
{
    public T value;
    public MyNode<T> next;

    public MyNode(T _value)
    {
        value = _value;
        next = null;
        
    }
}

