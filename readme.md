# Pseudo code

> Note: In pseudo code. first index is denoted by 1; unlike in programming it is denoted with 0

```
STACK-EMPTY(S)
  if S.top == 0
    return TRUE;
  else return FALSE;
  
PUSH(S,x)
  S.top = S.top + 1;
  S[S.top] = x;
  
POP(S)
  if STACK-EMPTY(S)
    error "underflow"
  else S.top = S.top - 1
    return [S.top + 1]
```


# Demostration

```
S = [];          // Start with empty array
-------

> PUSH(value1)   // First push i.e. top == 0

top = top + 1    // 1
S[top] = value1; // S[1] = value1

S = [value1]      
------------

> PUSH(value2)   

top = top + 1    // 2 
S[1] = value2;   // S[2] = value2

S = [value1, value2]
--------------------

> POP()  

top = top - 1;     // top = 2 - 1 = 1
return S[top + 1]  // return value of S[2] i.e. value2

S = [value1]
------------

> POP()  

top = top - 1;     // top = 1 - 1 = 0
return S[top + 1]  // return value of S[1] i.e. value1

S = []
------

> POP()  

top == 0
return "no item available for pop"
```
