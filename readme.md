# Pseudo code

> Note: In pseudo code. first index is denoted by 1; unlike in programming it is denoted with 0

```
ENQUEUE(Q, x)
  Q[Q.tail] = x
  if Q.tail == Q.length
    Q.tail = 1
  else
    Q.tail = Q.tail + 1

DEQUEUE(Q)
  x = Q[Q.head]
  if Q.head == Q.length
    Q.head = 1
  else 
    Q.head = Q.head + 1
  return x

```

# Demostration

```
Q = [3];         // Start with an array of length 3 i.e, [_ , _, _]
head = tail = 1 
-------

> ENQUEUE(value1)   // First enqueue i.e. head = tail = 1

Q[tail] = value1;   // Q[1] = value1

tail = tail + 1     // tail = 2, head = 1

Q = [value1]      
------------

> ENQUEUE(value2)   

Q[tail] = value2      // Q[2] = value2

tail = tail + 1       // tail = 3, head = 1

Q = [value1, value2]
--------------------

> ENQUEUE(value3)   

Q[tail] = value3;     // Q[3] = value3

tail == Q.length      // 3 == 3
tail = 1              // head = tail = 1

Q = [value1, value2, value3]
--------------------

> DEQUEUE()  

x = Q[head]        // x = Q[1] = value1

head = head + 1    // head = 2 tail = 1

return x           // return value1

Q = [_, value2, value 3]
------

> ENQUEUE(value4)   

Q[tail] = value4;     // Q[1] = value4
      
tail = tail + 1       // head = 2, tail = 2

Q = [value4, value2, value3]
--------------------

> DEQUEUE()  

x = Q[head]        // x = Q[2] = value2

head = head + 1    // head = 3 tail = 2

return x           // return value2

Q = [value4, _, value 3]
------------------------

> ENQUEUE(value5)   

Q[tail] = value4;     // Q[2] = value5
      
tail = tail + 1       // head = 3, tail = 3

Q = [value4, value5, value3]
----------------------------

> DEQUEUE()  

x = Q[head]        // x = Q[3] = value3

tail == Q.length
head = 1           // head = 1 tail = 3

return x           // return value3

Q = [value4, value5, _]
------------------------

> ENQUEUE(value6)   

Q[tail] = value4;     // Q[3] = value6

tail == Q.length
tail = 1              // head = 1, tail = 1

Q = [value4, value5, value6]
----------------------------


