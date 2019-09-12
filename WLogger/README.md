The overall goal of WLogger is to create a messaging system that meets the following requirements:


1.	There can only be one instance of an object that processes messages per application – all messages must be sent to a singular processor. 
2.	The message processor should have the ability to filter messages based on object type and at least one other filtering mechanism.
3.	There needs to be ability for many objects to send a message
4.	There needs to be an ability for any object to receive a message.
5.	A message must minimally contain a string message.
6.	A message must be able to optionally contain an object payload.
7.	Implement a basic message that contains a string message
8.	Implement an error message that contains an error level of high medium or low
9.	Implement a timestamped message that can report what time the message was created
10.	Implement a message with a payload of an object.
11.	Implement a message sender
12.	Implement a message receiver that can write received messages to disk
13.	Implement a message reciever that only writes error messages that are of level high.
14.	Use at least 3 design patterns of the following five:
	a.	Singleton Design Pattern
	b.	Chain of Responsibility
	c.	Observer pattern
	d.	Decorator pattern
	e.	Builder pattern

