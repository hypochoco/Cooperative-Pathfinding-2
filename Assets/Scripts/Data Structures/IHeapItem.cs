using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Extra property for RHeap
public interface IHeapItem<T> : IComparable<T> {
    public int HeapIndex { get; set; }
}