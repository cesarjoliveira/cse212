using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    public void TestEnqueue_AddsItemToQueue()
    {
        // Scenario: Add two items to the queue
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);

        // Expected Result: The queue should contain two items in the correct order
        Assert.AreEqual("[A (Pri:1), B (Pri:2)]", priorityQueue.ToString());
    }

    [TestMethod]
    public void TestDequeue_RemovesHighestPriorityItem()
    {
        // Scenario: Add three items with different priorities
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        // Expected Result: The item with the highest priority (B) should be dequeued first
        var dequeuedItem = priorityQueue.Dequeue();
        Assert.AreEqual("B", dequeuedItem);
    }

    [TestMethod]
    public void TestDequeue_RemovesFIFOWhenPriorityIsEqual()
    {
        // Scenario: Add multiple items with the same priority
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        // Expected Result: FIFO behavior should be followed, so "A" should be dequeued first.
        var dequeuedItem1 = priorityQueue.Dequeue();
        Assert.AreEqual("A", dequeuedItem1);

        // "B" should be dequeued next, as it has the same priority as "A"
        var dequeuedItem2 = priorityQueue.Dequeue();
        Assert.AreEqual("B", dequeuedItem2);
    }

    [TestMethod]
    public void TestDequeue_ThrowsExceptionOnEmptyQueue()
    {
        // Scenario: Attempt to dequeue from an empty queue
        var priorityQueue = new PriorityQueue();

        // Expected Result: An InvalidOperationException should be thrown
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    public void TestEnqueueAndDequeue_MultipleOperations()
    {
        // Scenario: Enqueue multiple items and perform multiple dequeues
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        // Expected Result: The highest priority item ("B") should be dequeued first
        Assert.AreEqual("B", priorityQueue.Dequeue());

        // Then, the item with priority 4 ("D") should be added and dequeued
        priorityQueue.Enqueue("D", 4);
        Assert.AreEqual("D", priorityQueue.Dequeue());

        // Continue with the rest of the queue
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }
}
