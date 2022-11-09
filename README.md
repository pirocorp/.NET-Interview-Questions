# Q1: Let’s summarize the differences between Tuples and ValueTuples:

- tuples are reference types, ValueTuples are value types. When a lot of short-lived tuples are created, it may decrease the performance of the application as the memory management for reference types is more demanding than for value types
- tuples are immutable, ValueTuples are mutable
- ValueTuples provide a convenient syntax for the creation
- In tuples, all properties are named Item1, Item2, etc. ValueTuples can have named fields.
- tuples have properties, ValueTuples have fields
- ValueTuples can easily be declared with more than 8 elements, and the compiler will translate them to ValueTuples with 8 elements with the last element being the “Rest” field, holding the excess elements. We can do the same with tuples but we must set the Rest property by hand


## Q1.1: Is it possible to have a tuple with more than 8 elements

Tuples are limited to hold up to 8 elements, however, we can bypass this
limitation by storing the excessive data in the last property called (for example) “Rest” which is also a tuple, making our tuple nested. This is quite awkward for tuples, but for ValueTuples we get some help from the compiler - it allows us to use the tuple like it really contained more than 8 elements, for example by using Item12 field. Behind the scenes, the compiler will change this to the usage of tuple.Rest.Item5.


# Q2: What is the difference between "is" and "as" keywords?

- The "**is**" keyword checks if the object is of a given type. It returns a boolean result.
- The "**as**" keyword casts an object to a given type. It can only be used for casting to a reference type or nullable value type.


## Q2.1: What is the difference between classic cast and casting with "as"?

- Casting with "as" can be only used for casting to reference types or nullable types. It is because **when the cast will not succeed the result will be null** - so the type we cast to must be nullable. For example, an integer can't be null, so you can't use casting with "as" to cast to an int.

- Regular casting with parenthesis can be used to cast to all types. If the cast **will not succeed the InvalidCastException will be thrown**.


## Q2.2: What is the difference between regular casting and casting with "as" keyword?

When casting with "as" fails, it will return null. When regular casting fails, an
InvalidCastException will be thrown.


## Q2.3: Why can we only use the "as" keyword to cast objects to nullable types?

Because if casting with "as" fails, null will be returned. Null can only be assigned to nullable types.


# Q3: What is the use of the “using” keyword?

- **The using directive** 
	- They allow us to use types from the listed namespaces.
	- The other use of the using directive is to create **aliases** for some types names.
	- **The global using directive**. When a type is imported in any file with this directive, it is like it was imported in all files in the project.

- **The using statement**
	- It is used to define the scope in which the IDisposable object will be used, and that will be disposed of at the scope's end


## Q3.1: What are the global using directives?

When a type is imported in any file with the global using directive, it is like it was imported in all files in the project. This is convenient when some namespace (like, for example, System.Linq) is used in almost every file in the project.


# Q4: What is the purpose of the “dynamic” keyword?

The “dynamic” keyword allows us to bypass static type checking that is done by default by the C# compiler. We can call any operations on dynamic variables and the code will still compile. Whether the operation is available in this object or not will only be checked at runtime. The “dynamic” keyword is most useful when working with types unknown in our codebase, like types being the result of dynamically-typed languages scripts or COM objects.


## Q4.1: What is the difference between strongly-typed and weakly-typed programming languages?

In weakly-typed languages, variables are automatically converted from one type to another. In strongly-typed languages, this will not be the case. For example, in C#, which is a strongly-typed language, the “2”+8 expression will not compile, while in weakly-typed Perl it will give 10 as a result.


## Q4.2: What is the difference between statically-typed and dynamically-typed programming languages?

In statically-typed languages, the type checks are done at the compile time, while in dynamically-typed languages they are done at runtime. For example, in C# we can’t pass an integer to a method expecting a string. In Python, which is dynamically typed, we can, but the execution would result in a runtime error if in this method I would call some operation that is not available in int type.


## Q4.3: What are COM objects?

COM stands for “Component Object Model” and it’s a binary-interface standard for Windows software components. In simple terms, a COM object is something that can be understood by different Windows programs, and for example, it can allow communication between Excel and C# programs.


# Q5: What are expression-bodied members?

Expression-bodied members of a type are members defined with expression body instead of the regular body with braces. Using them allows us to shorten the code significantly. 

- So the general blueprint for expression-bodied methods is this: ```type name => expression```


## Q5.1: What is an expression?

An expression is a piece of code that evaluates to some value. For example ```2 + 5``` evaluates to `7`.


## Q5.2: What is a statement?

A statement is a piece of code that does something but does not evaluate to a value.


# Q6: What are Funcs and lambda expressions?

In C#, we can treat functions like any other types - assign them to variables or pass them as parameters to other functions. The Func and Action types allow us to represent functions. Lambda expressions are a special way of declaring anonymous functions. They allow us to define functions in a concise way and are most useful when those functions will not be used in a different context.

- ```param => expression```
- ```(p1, p2) => expression```


## Q6.1: What is the signature of a function that could be assigned to the variable of type Func<int, int, bool>?

It would be a function that takes two integers as parameters and returns a bool.


## Q6.2: What is an Action?

Action is a type used to represent void functions. It works similarly to Func, but Func can only represent non-void functions.


# Q7: What are delegates?

A delegate is a type whose instances hold a reference to a method with a particular parameter list and return type.


## Q7.1: What is the difference between a Func and a delegate?

Func is a delegate, simply defined by Microsoft, not us. To be more precise, Func is a generic delegate used to represent any function with given parameters and returned type. A delegate is a broader concept than Func - we can define any delegate we want, and it doesn’t need to be generic at all.


## Q7.2: What is a multicast delegate?

It’s a delegate holding references to more than one function.


# Q8: How does the Garbage Collector decide which objects can be removed from memory?

Garbage collector removes those objects, to which no references point. To decide whether a reference pointing to some object exists, the Garbage Collector builds a graph of all objects reachable from root objects of the application, which are things like references currently stored on the stack or in static fields of classes. If an object will not be included in this graph, it means it’s not needed and can be removed from memory. After the graph of reachability is built, the Garbage Collector can continue its work and remove the unreachable objects.


## Q8.1: What is the Mark-and-sweep algorithm?

It’s the algorithm that the Garbage Collector implements. According to this algorithm, the GC first marks objects that can be removed (mark phase) and then actually removes them (sweep phase).


## Q8.2: How many stacks are there in a running .NET application?

As many as threads. Each thread has its own stack.


## Q8.3: What two main algorithms of identifying used and unused objects are implemented by tools similar to .NET Garbage Collector?

First is reference counting, which associates a count of references pointing to an object with each object. An example of a language using it is Swift. Another algorithm is tracing (this one is used in .NET) which builds a graph of reachability starting from the application roots.


# Q9: What are generations?

The Garbage Collector divides objects into three generations - 0, 1, and 2 - depending on their longevity. Short-lived objects belong to generation 0, and if they survive their first collection, they are moved to generation 1, and after that - to generation 2. The Garbage Collector collects objects from generation 0 most often, and from generation 2 least often. This feature is introduced in order to improve Garbage Collector’s performance. Objects that survived a couple of cycles of the GC’s work tend to be long-lived and they don’t need to be checked upon so often. This way, the Garbage Collector has less work to do, so it can do it faster.


## Q9.1: What is the Large Objects Heap?

It’s a special area of the heap reserved for objects larger than 85 000 bytes. Such objects logically belong to generation 2 from the very beginning of their existence and are pinned.


## Q9.2: What does it mean that the object is pinned?

It means it will not be moved during the memory defragmentation that the Garbage Collector is executing. It is an optimization, as large objects are expensive to move, and it’s hard to find a chunk of memory large enough for them.


# Q10: What is the difference between Dispose and Finalize methods?

The Dispose method is used to free unmanaged resources. The Finalize method is the same thing as the destructor, so it’s the method that is called on an object when it is being cleaned up by the Garbage Collector.

- The Garbage Collector does not call the Dispose method.


## Q10.1: What is the difference between a destructor, a finalizer, and the Finalize method?

There is no difference, as they are the same thing. During the compilation, the destructor gets changed to the Finalize method which is commonly called a finalizer.


## Q10.2: Does the Garbage Collector call the Dispose method?

No. The Garbage Collector is not aware of this method. We must call it ourselves, usually by using the using statement.


## Q10.3: When should we write our own destructors?

The safest answer is “almost never”. Destructors are very tricky and we don’t even have a guarantee that they will run. Use IDisposable instead.


## Q10.4: What are managed and unmanaged resources?

- The **managed resources** are managed by the Common Language Runtime. Any objects we create with C# are managed resources. The Garbage Collector is aware of their existence, and once they are no longer needed it will free up the memory they occupy. That means we don’t need to worry about managed resources cleanup as it is done automatically for us. 
- **Unmanaged resources** are beyond the realm of the CLR. The Garbage Collector doesn’t know about them, so it will not perform any cleanup on them. Examples of unmanaged resources are database connections, file handlers, COM objects, opened network connections, etc. We as developers are responsible to perform the cleanup after we are done with those objects.


# Q11: What are default implementations in interfaces?

Starting with C# 8, we can provide methods implementations in interfaces. This feature was mostly designed to make it easier to add new methods to existing interfaces without breaking the existing code.


## Q11.1 What can be the reason for using default implementations in interfaces?

Default implementations in interfaces are mostly designed to make it easier to add new methods to existing interfaces without breaking the existing code. Without it, if we add a method to an interface we release it as a public library, we will force everyone who updates this library to provide the implementation immediately - otherwise, their code will not build.


# Q12: What is deconstruction?

Deconstruction is a mechanism that allows breaking a tuple or a positional record into individual variables. It is also possible to define how deconstruction should work for user-defined types by implementing the Deconstruct method.


## Q12.1: What is the difference between the destructor and the Deconstruct method?

The destructor is a method that’s called on an object when this object is being removed from memory by the Garbage Collector. The Deconstruct method allows the object to be deconstructed into single variables. It is by default generated for Tuples, ValueTuples, and positional records, but we can also define it in custom types.


## Q12.2: How can we define deconstruction for types that we did not create and we don’t have access to their source code?

We can define the Deconstruct method as an extension method for this type.


# Q13: 13. Why is “catch(Exception)” almost always a bad idea (and when it is not?)?

Using “catch(Exception)” should be avoided, because it catches every kind of exception. When we decide to catch an exception, we should know how to handle it, and it’s not feasible if the exception’s type is unknown. The acceptable use cases for catching any type of exceptions are:
- The global catch block that is catching all exceptions not handled elsewhere and shows them to the user.
- Any catch block in which we rethrow an exception without handling it.


## Q13.1: What are the acceptable cases of catching any type of exception?

The acceptable use cases for catching any type of exceptions are:
- The global catch block that is catching all exceptions not handled elsewhere and shows them to the user.
- Any catch block in which we rethrow an exception without handling it.


## Q13.2: What is the global catch block?

The global catch block is the catch block defined at the upper-most level of the application, that is supposed to catch any exceptions that hadn’t been handled elsewhere. It usually logs the exception and shows some information to the user, before stopping the application.


# Q14: What is the diff erence between “throw” and “throw ex”?

The diff erence between “throw” and “throw ex” is that “throw” preserves the stack trace (the stack trace will point to the method that caused the exception in the fi rst place) while ”throw ex” does not preserve the stack trace (we will lose the information about the method that caused the exception in the fi rst place. It will seem like the exception was thrown from the place of its catching and re-throwing)


## Q14.1: What is the stack trace?

The stack trace is a trace of all methods that have been called, that lead to the current moment of the execution. At the top of the stack trace we have the method that has been called most recently, and at the bottom - the one that has been called fi rst. Stack trace allows us to locate the exact line in code that was the source of an exception.


## Q14.2: Should we use “throw” or “throw ex”, and why?

We should use “throw” as it preserves the stack trace and helps us find the original source of the problem.


# Q15: What is the diff erence between typeof and GetType?

Both **typeof** keyword and the **GetType** method are used to get the information about some type. The differences between them are:
- **typeof** takes the name of the type we want to inspect, so we must know the type before. **typeof** is resolved at compile time.
- **GetType** is a method that must be executed on an object. Because of that, it is resolved at runtime. This method comes from the **System.Object** base class, so it is available in any object in C#.


## Q15.1: What is the purpose of the GetType method?

This method returns the Type object which holds all information about the type of the object it was called on. For example, it contains the type name, list of the constructors, attributes, the base type, etc.


## Q15.2: Where is the GetType method defined?

It is defined in the **System.Object** type, which is a base type for all types in C#. This is why we can call the **GetType** method on objects of any type.


# Q16: What is reflection?

Reflection is a mechanism that allows us to write code that can inspect types used in the application. For example, using reflection, we can list all fields and their values belonging to a given object, even if at compile time we don’t know what type it is exactly.
- loading dlls at runtime and using them
- instantiating a new instance of some object of a specific type at runtime. For example, we can create an object of a type defined in a dll we loaded reading private fields or properties, executing private methods (don’t overuse it!)
- finding all classes derived from a specific base type or implementing a specific interface
- reading the attributes. This is for example what NUnit does when it runs the tests. It finds all methods with the \[Test\] attribute and executes them. We will learn more about attributes in the next lecture
- running a method by its name, for example, if the user of the application selected if from some dropdown
- debugging. For example, sometimes it is necessary to fi nd out the list of currently loaded assemblies
- creating new types at runtime (System.Refl ection.Emit namespace is used for that)
- and many more


## Q16.1: What are the downsides of using refl ection?

Using reflection has a relatively big impact on performance. Also, it makes the code hard to understand and maintain. It may also tempt some programmers to “hack” some code, for example, to access private fields at runtime, which may lead to unexpected results and hard-to-understand bugs.


# Q17: What are attributes?

Attributes add metadata to a type. In other words, they are a way to add information about a type or method to the metadata which describes that type or method.


## Q17.1: What is metadata?

Generally speaking, metadata is data providing information about other data. For example, when working with databases, the data stored inside the database is the actual data, while the structure of tables and relations between them is metadata. In programming, metadata describes types used in an application. We can access it in the runtime using reflection, to get the information about some type, for example, what methods or what constructors it contains.


## Q17.2: How to define a custom attribute?

To define a custom attribute we must defi ne a class that is derived from the Attribute base class.


# Q18: What is serialization?

Serialization is the process of converting an object into a format that can be stored in memory or transmitted over a network. For example, the object can be converted into a text file containing JSON or XML, or a binary file.


## Q18.1: What are the uses of serialization?

It can be used to send objects over a network, or to store objects in a file for later reconstruction, or even to store them in a database - for example to save a "snapshot" of an object every time a user makes some changes to it, so we can log the history of the changes.


## Q18.2: What does the Serializable attribute do?

This attribute indicates that instances of a class can be serialized with **BinaryFormatter** or **SoapFormatter**. It is **not required** for **XML** or **JSON** serialization.


## Q18.3: What is deserialization?

Deserialization is the opposite of serialization: it’s using the content of a file to recreate objects.


# Q19: What is pattern matching?

Pattern matching is a technique where you test an expression to determine if it has certain characteristics.


## Q19.1: How can we check if an object is of a given type, and cast to it this type in the same statement?

We can use pattern matching for that. For example, we could write ```if (obj is string text)```. This way, we will cast the object to the string variable called text, but only if this object is of type string.


# Q20: How does the binary number system work?

The binary number system is used to represent numbers using only two digits - 0 and 1. For example, the number 13 (in the decimal number system) is 1101 in the binary number system. All data in a computer’s memory is stored as sequences of bits, and so are all numbers.


## Q20.1: What is the decimal representation of number 101?

It’s 5 because it’s 2 to the power of zero plus two to the power of 2, which gives 1 + 4 = 5.


## Q20.2: Why arithmetic operations in programming can give unexpected results, like for example adding two large integers can give a negative number?

Because there is a limited number of bits reserved for each numeric type, for example for integer it’s 32 bits. If the result of the arithmetic operation is so large that it doesn’t fit on this amount of bits, some of the bits of the result will be trimmed, giving an unexpected result that is not valid.


# Q21: What is the purpose of the “checked” keyword?

The “checked” keyword is used to define a scope in which arithmetic operations will be checked for overflow.


## Q21.1: What is the purpose of the "unchecked" keyword?

This keyword defines a scope in which check of arithmetic overfl ow is disabled. It makes sense to use it in projects in which the checking for overfl ow is enabled for an entire project (can be set on the project level settings).


## Q21.2: What is a silent failure?

It’s a kind of failure that happens without any notifi cation to the users or developers - they are not informed that something went wrong, and the application moves on, possibly in an invalid state.


## Q21.2: What is the BigInteger type?

It’s a numeric type that can represent an integer of any size - it is limited only by the application’s memory. It should be used to represent gigantic numbers (remember that max long is over 4 billion times larger than max int, which is a bit more than two billion, so BigInteger should be used instead of long only to represent unthinkably large numbers)


# Q22: What is the diff erence between double and decimal?

The difference between **double** and **decimal** is that **double** is a floating-point **binary** number, while decimal is a floating-point **decimal** number. Double is optimized for performance, while decimal is optimized for precision. Doubles are much faster, they occupy less memory and they have a larger range, but they are less precise than decimals.

- doubles are optimized for performance, decimals are optimized for precision
- decimals have worse performance than doubles
- decimals have a smaller range than doubles - they can’t represent really tiny or really large numbers
- because of all that, decimals shall be used when we care about precision, for example, we want to compare two sums of money and tell if they are exactly equal or not. For the same usage, doubles are less precise but faster. They are perfect for representing numbers that are not human-made but rather come from nature or physics, like the speed of a car or the length of a wave. When checking two doubles for equality we should only check if they are close to each other within some tolerance.


## Q22.1: What is the diff erence between double and float?

The only difference is that double occupies 64 bits of memory while float occupies 32, giving double a larger range. Except for that, they work exactly the same.


## Q22.2: What is the NaN?

NaN is a special value that double and fl oat can be. It means Not a Number, and it’s reserved for representing results of undefi ned mathematical operations, like dividing infi nity by infinity.


## Q22.3: What numeric type should we use to represent money?

When representing money we should always use decimals.


# Q23: What is an Array?

Array is the basic collection type in C#, storing elements in an indexed structure of fixed size. Arrays can be single-dimensional, multi-dimensional, or jagged.


## Q23.1: What is a jagged array?

A jagged array is an array of arrays, which can be all of the different lengths.


## Q23.2: What are the advantages of using arrays?

They are fast when it comes to accessing an element at the given index. They are basic and easy to use and great for representing simple data of size that is known upfront.


## Q23.3: What are the disadvantages of using arrays?

Arrays are of fi xed size, which means once created, they can’t be resized. It means that are not good for representing dynamic collections that grow or shrink over time. If we want to allocate the memory for all elements that may be stored, there is a chance we will allocate too much and waste it. We can also underestimate and not declare the array big enough for some edge cases.


## Q23.4: How to resize an array?

It’s not possible. An array is a collection of a fixed size and once created, it can’t be resized.


# Q24: What is a List?

List<T> is a strongly-typed, generic collection of objects. Lists are dynamic, which means we can add or remove the elements from them. It uses an array as the underlying collection type. As it grows, it may copy the existing array of elements to a new, larger array.


## Q24.1: Why it is a good idea to set the Capacity of the List in the constructor if we know the expected count of elements upfront?

Because this way we will avoid the performance-costly operation of copying the underlying array into a new, larger one, which happens when we exceed the count of 4, 8, 16… elements.


## Q24.2: What’s the time complexity of the Insert method from the List class?

The Insert method needs to move some of the elements of the underlying array forward, to make room for the new element. In the worst-case scenario, when we insert an element at the beginning of the List, we will need to move all existing elements. This means the complexity of this operation is O(N).


# Q25: What is an ArrayList?

An ArrayList is a collection that can store elements of any type, as it considers them all instances of the System.Object. ArrayLists were widely used in older versions of C#, where the generics were not yet available. Nowadays they should not be used, as their performance is impacted by the fact that they need to box value types.


## Q25.1: What is the difference between an array, a List, and an ArrayList?

An array is a basic collection of fixed size that can store any declared type of elements. The List is a dynamic collection (it means, its size can change over time) that is generic, so it can also store any declared type of elements. An ArrayList is a dynamic collection that can store various types of elements at the same time, as it treats everything it stores as instances of the System.Object type.


## Q25.2: When to use ArrayList over a generic List<T>?

Never, unless you work with a very old version of C#, which did not support generics. Even if you do, you should rather upgrade .NET to a higher version than work with ArrayLists.


# Q26: What is the purpose of the GetHashCode method?

The GetHashCode method generates an integer for an object, based on this object’s fi elds and properties. This integer, called hash, is most often used in hashed collections like **HashSet** or **Dictionary**.


## Q26.1: Can two objects of the same type, different by value, have the same hash codes?

Yes. Hash code duplications (or “hash code conflicts”) can happen, simply because the count of distinct hash codes is equal to the range of the integer, and there are many types that can have much more distinct objects than this count.


## Q26.2: Why it may be a good idea to provide a custom implementation of the GetHashCode method for structs?

Because the default implementation uses refl ection, and because of that is slow. A custom implementation may be signifi cantly faster, and if we use this struct as a key in hashed collections extensively, it may improve the performance very much.


# Q27: What is a Dictionary?

A Dictionary is a data structure representing a collection of key-value pairs. Each key in the Dictionary must be unique. The underlying data structure of a Dictionary is a hash table. A hash table is basically an array of linked lists. We can imagine it like this


## Q27.1: What is a hash table?

A hash table is a data structure that stores values in an array of collections. The index in the array is calculated using the hash code. It allows quick retrieval of objects with given hashcode. A hash table is the underlying data structure of Dictionary.


## Q27.2: Will the Dictionary work correctly if we have hash code confl ict for two of its keys?

Yes. The Dictionary still can tell which key is which using the Equals method, so it will not mistake them only because they have the same hash codes.


## Q27.3: Why should we override the Equals method when we override the GetHashCode method?

Because the Equals method is needed for the Dictionary to distinguish two keys in case of the hash code conflict, and because of that its implementation should be in line with the implementation of the GetHashCode method. For example, if GetHashCode returns the social security number for a Person object, it means we consider this number the Person’s identifier. The Equals method should also only compare the social security numbers.


# Q28: What are indexers?

Indexers allow instances of a type to be indexed just like arrays. In this way, they resemble properties except that they take parameters. For example, a Dictionary<string, int> has an indexer that allows calling ```dictionaryVariable["some key"]``` to access the value under some key.


## Q28.1: Is it possible to have a class with an indexer accepting a string as a parameter?

Yes. We can defi ne indexers with any parameters. An example of such a class can be a Dictionary<string, int> as we access its elements like ```dict["abc"]```.


## Q28.2: Can we have more than one indexer defi ned in a class?

Yes. Just like with method overloading, we can have as many indexers as we want, as long as they differ by the type, count, or order of parameters.


# Q29: What is caching?

Caching is a mechanism that allows storing some data in memory, so next time it is needed, it can be served faster.


## Q29.1: What are the benefits of using caching?

Caching can give us a performance boost if we repeatedly retrieve data identified by the same key. It can help not only with data retrieved from an external data source but even calculated locally if the calculation itself is heavy (for example some complex mathematical operations).


## Q29.2: What are the downsides of using caching?

Cache occupies the application’s memory. It may grow over time, and some kind of cleanup mechanism should be introduced to avoid OutOfMemoryExceptions. Such mechanisms are usually based on the expiration time of the data. Also, the data in the cache may become stale, which means it changed at the source but the old version is cached and used in the application. Because of that, caching is most useful when retrieving data that doesn’t change often.


# Q30: What are immutable types and what’s their purpose?

Immutability of a type means that once an object of this type is created none of its fields of properties can be updated. Using immutable types over mutable ones gives a lot of benefits, like making the code simpler to understand, maintain and test, as well as making it thread-safe.

- Clarity and simplicity of the code
- Pure functions
- Thread safety
- No invalid objects
- Prevention of identity mutation
- Easier testing



## Q30.1: What are pure functions?

Pure functions are functions whose results only depend on the input parameters, and they do not have any side effects like changing the state of the class they belong to or modifying the objects passed as an input.


## Q30.2: What are the benefits of using immutable types?

The code using immutable types is simple to understand. Immutable types make it easy to create pure functions. Using immutable types makes it easier to work with multithreaded applications, as there is no risk that one thread will modify a value that the other thread is using. Immutable objects retain their identity and validity. Mutable objects make testing problematic. Testing code using immutable types is simpler.


## Q30.3: What is the non-destructive mutation?

The non-destructive mutation is an operation of creating a new object based on another immutable object. The immutable object won’t be modified, but the result of *modification* will become a new object. The real-life analogy could be adding 7 days to a date of January the 1st. It will not change the date of January the 1st, but it will produce a new date of January the 8th.


# Q31: What are records and record structs?

Records and record structs are new types introduced in C# 9 and 10. They are mostly used to define simple types representing data. They support value-based equality. They make it easy to create immutable types.

- Records are reference types
- But they are based on value-type equality, which means, two records with identical values of properties will be considered equal even if they differ by reference
- Like classes, they support inheritance
- The compiler generates the following methods for records:
  - an override of Equals(object?) method
  - a virtual Equals(ThisRecord?) method (this method comes from the IEquatable<ThisRecord> interface which records implement)
  - and override for the GetHashCode method
  - overloads of == and != operators
  - an override of the ToString method, which prints the names of the properties with their values
- For positional records, the compiler also generates
  - a primary constructor whose parameters match the positional parameters on the record declaration
  - public properties for each parameter of a primary constructor. Those properties are read-only (but they are not for record structs)
  - a Deconstruct method to extract properties from the record


## Q31.1: What is the purpose of the "with" keyword?

The “with” keyword is used to create a copy of a record object with some properties set to new values. In other words, it’s used to perform a non-destructive mutation of records.


## Q31.2: What are positional records?

Positional records are records with no bodies. The compiler generates properties, constructor, and the Deconstruct method for them. They are a shorter way of defi ning records, but we can’t add custom methods or writable properties to a positional record.


# Q32: Why does string behave like a value type even though it is a reference type?

String is a reference type with the value type semantics. All strings are immutable, which means when they seem to be modified, actually, a new, altered string is created. String has value-type semantics as this is more convenient for developers, but it can’t be a value type because string objects can be large, and value types are stored on the stack which has a limited size.


## Q32.1: What is interning of strings?

Interning means that if multiple strings are known to be equal, the runtime can just use a single string, thereby saving memory. This optimization wouldn’t work if strings were mutable, because then changing one string would have unpredictable results on other strings.


## Q32.2: What is the size of the stack in megabytes?

It’s 1 MB for 32-bit processes and 4 MB for 64-bit processes.


## Q32.3: What is the underlying data structure for strings?

It’s an array of chars. Arrays by definition have fixed size, which is a reason why strings are immutable - we couldn’t modify a string by adding new characters to it, because they wouldn’t fit in the underlying array.


# Q33: What is the diff erence between string and StringBuilder?

String is a type used for representing textual data. StringBuilder is a utility class created for optimal concatenation of strings.


## Q33.1: What does it mean that strings are immutable?

It means once a string is created, it can’t be modifi ed. When we modify a string, actually a brand-new string is created and the variable that stored it simply has a new reference to this new object.


# Q34: What is operator overloading?

Operator overloading is a mechanism that allows us to provide custom behavior when objects of the type we defined are used as operands for some operators. For example, we can define what will ```obj1 + obj2``` do.


## Q34.1: What is the purpose of the "operator" keyword?

It is used when overloading an operator for a type.


## Q34.2: What is the difference between explicit and implicit conversion?

Implicit conversion happens when we assign a value of one type to a variable of another type, without specifying the target type in the parenthesis. For example, it happens when assigning an int to a double. Explicit conversion requires specifying the type in parenthesis, for example when assigning a double to an int.


# Q35: What are anonymous types?

Anonymous types are types without names. They provide a convenient way of encapsulating a set of read-only properties into a single object without having to explicitly define a type first.


## Q35.1: Can we modify the value of an anonymous type property?

No. All properties of anonymous types are read-only.


## Q35.2: When should we, and when should we not use anonymous types?

The best use case for anonymous types is when the type we want to use is simple and local to some specifi c context and it will not be used anywhere else. It’s very often used as a temporary object in complex LINQ queries. If the type is complex or we want to reuse it, it should not be anonymous. Also, anonymous types can only provide read-only properties; they can’t have methods, fi elds, events, etc, so if we need any of those features the anonymous types will not work for us.


## Q35.3: Are anonymous types value or reference types?

They are reference types since they are classes, but they support value-based Equality with the Equals method. In other words, two anonymous objects with the same values of properties will be considered equal by the Equals method even if their references are different.


# Q36: What is cohesion?

Cohesion is the degree to which elements of a module belong together. In simpler words, it measures how strong the relationship is between members of a class. High cohesion is a desirable trait of the classes and modules.

High cohesion gives us a lot of benefi ts:
- Highly cohesive classes are easier to understand and use. They provide a highly-focused set of operations instead of more functionality than we need. Think of our OwnerNotifi er class - it could easily be reused to send some other information to the person living at some address.
- When a change is needed, it’s easier to introduce, as it affects fewer modules.
- Cohesive classes are easy to test.
- They are reusable.


## Q36.1: Is following the Single Responsibility Principle and keeping high cohesion the same thing?

No, but it’s common that a highly cohesive class meets the SRP and vice versa. High cohesion means that the data and methods that belong together, are kept together. If following only the SRP, we could (but it doesn’t mean we should!) keep splitting classes into smaller pieces until every class would have only one public method. Each of those tiny classes would defi nitely meet the SRP, as they would only have a single responsibility and single reason to change. But they wouldn’t be cohesive, as they should belong together.


# Q37: What is coupling?

Coupling is the degree to which one module depends on another module. In other words, it’s a level of “intimacy” between modules. If a module is very close to another, knows a lot about its details, and will be aff ected if the other changes, it means they are strongly coupled.

The perfect classes and modules should be highly cohesive and loosely coupled.


## Q37.1: How to recognize strongly couples types?

One type uses another type directly, without having any abstraction in between. We often recognize strong coupling the hard way: when we see that even a small change in a class leads to a cascade of changes all around the project. It proves that the types are not independent.


## Q37.2: Which of the SOLID principles allow us to reduce coupling?

The Dependency Inversion Principle, which says that classes shouldn’t depend on concrete implementations, but rather on abstractions. When following this principle we remove the direct way of communication between classes, making them more independent from each other.


# Q38: What is the Strategy design pattern?

The Strategy Design pattern is a pattern that allows us to define a family of algorithms to perform some tasks. The concrete strategy can be chosen at runtime.


## Q38.1: What are the benefits of using the Strategy design pattern?

It helps to reduce code duplications, makes the code cleaner and more easily testable. It separates the code that needs to be changed often (the particular strategy) from the code that doesn’t change that much (the code using the strategy).


# Q39: What is the Dependency Injection design pattern?

Dependency Injection is providing the objects some class needs (its dependencies) from the outside, instead of having it construct them itself.


## Q39.1: What are Dependency Injection frameworks?

Dependency Injection frameworks are mechanisms that automatically create dependencies and inject them into objects that need them. They are confi gurable, so we can decide what concrete types will be injected into objects depending on some abstractions. They can also be confi gured to reuse one instance of some type or to create separate instances for each object that needs them. Some of the popular Dependency Injection frameworks in C# are Autofac or Ninject.


## Q39.2: What are the benefi ts of using Dependency Injection?

Dependency Injection decouples a class from its dependencies. The class doesn’t make the decision of what concrete type it will use, it only declares in the constructor what interfaces it will need. Thanks to that, we can easily switch the dependencies according to our needs, which is particularly useful when injecting mock implementations for testing purposes.


# Q40: What is the Template Method design pattern?

Template Method is a design pattern that defi nes the skeleton of an algorithm in the base class. Specifi c steps of this algorithm are implemented in derived classes.


## Q40.1: What is the diff erence between the Template Method design pattern and the Strategy design pattern?

Both patterns allow specifying what concrete algorithm or a piece of the algorithm will be used. The main difference is that with the Template Method, it is selected at compile-time, as this pattern uses the inheritance. With the Strategy pattern, the decision is made at runtime, as this pattern uses composition.


# Q41: What is the Decorator design pattern?

Decorator is a design pattern that dynamically adds extra functionality to an existing object, without affecting the behavior of other objects from the same class.


## Q41.1: What are the benefi ts of using the Decorator design pattern?

The Decorator pattern allows us to easily add functionality to objects, without touching the original classes, so it’s very much in line with the Open-Closed Principle. It allows us to keep classes simple. It makes it easy to stack functionalities together, building complex objects from simple classes. It also helps us to be in line with the Single Responsibility Principle, as each class now has a very focused responsibility. They would be easy to test, maintain, and generally pleasant to works with.


# Q42: What is the Observer design pattern?

The Observer design pattern allows objects to notify other objects about changes in their state.


## Q42.1: In the Observer design pattern, what is the Observable and what is the Observer?

The Observable is the object that’s being observed by Observers. The Observable notifies the Observers about the change in its state.


# Q43: What are events?

Events are the .NET way of implementing the Observer design pattern. They are used to send a notification from an object to all objects subscribed.


## Q43.1: What is the difference between an event and a field of the delegate type?

A public field of a delegate type can be invoked from anywhere in the code. Events can only be invoked from the class they belong to.


## Q43.2: Why is it a good practice to unsubscribe from events when a subscribed object is no longer needed?

Because as long as it is subscribed, a hidden reference between the observable and the observer exists, and it will prevent the Garbage Collector from removing the observer object from memory.


# Q44: What is Inversion of Control?

Inversion of Control is the design approach according to which the control flow of a program is inverted: instead of the programmer controlling the flow of a program, the external sources (framework, services, other components) take control of it.

Speaking more generally, the Inversion of Control happens whenever some kind of a callback is defined. A callback is an executable code (a method in C#) that gets passed as an argument to some other code.


## Q44.1: What is a callback?

A callback is an executable code (a method in C#) that gets passed as an argument to some other code.


## Q44.2: What is the difference between a framework and a library?

According to Martin Fowler (author of the great book “Refactoring” and in general authority in topics of software development, design, etc.) the Inversion of Control is what makes the diff erence between a framework and library. A library is essentially a set of functions that you can call, these days usually organized into classes. Each call does some work and returns control to the client. A framework embodies some abstract design, with more behavior built in. In order to use it, you need to insert your behavior into various places in the framework either by subclassing or by plugging in your own classes. The framework's code then calls your code at these points.


# Q45: What is the “composition over inheritance” principle?

“Composition over inheritance” is a design principle stating that we should favor composition over inheritance. In other words, we should reuse the code by rather containing objects within other objects, than inheriting one from another.


## Q45.1: What is the problem with using composition only?

If we decide not to use inheritance at all, we make it harder for ourselves to define types that are indeed in an “IS-A” relation - so when one type IS the other one. For example, a Dog IS an Animal, or an Employee IS a person. When implementing such hierarchy with the composition we create very similar types that wrap other types only adding a bit of new functionality, and they mostly contain forwarding methods.


## Q45.2: What are forwarding methods?

They are methods that don’t do anything else than calling almost identical methods from some other type. Forwarding methods indicate a very close relationship between types, which may mean that one type should be inherited from another.


# Q46: What are mocks?

Mocks are objects that “pretend” to be other objects and are used mostly for testing purposes.


## Q46.1: What is Moq?

Moq is a popular mocking library for C#. It allows us to easily create mocks of interfaces, classes, Funcs, or Actions. It gives us the ability to decide what result will be returned from the mocked functions, as well as validate if some function has been called, how many times, and with what parameters.


## Q46.2: What is the relation between mocking and Dependency Injection?

Mocking is hard to implement without the Dependency Injection. Dependency Injection allows us to inject some dependencies to a class, so we can choose whether we inject real implementations or mocks. If the dependency of the class would not be injected but rather created right in the class, we could not switch it to a mock implementation for testing purposes.


# Q47: What are NuGet packages?

NuGet packages contain compiled code that someone else created, that we can reuse in our projects. The tool used to install and manage them is called NuGet Package Manager.


# Q48: What is the diff erence between Debug and Release builds?

During the Release build, the compiler applies optimizations it finds appropriate. Because of that, the result of the build is often smaller and it works faster. On the other hand, it’s harder to debug because the compiled result doesn’t match the source code exactly.


## Q48.1: How can we execute some piece of code only in the Debug, or only in the Release mode?

By placing it inside a ```#if DEBUG``` or ```#if RELEASE``` conditional preprocessor directives.


# Q49: What are preprocessor directives?

Preprocessor directives help us control the compilation process from the level of the code itself. We can choose if some part of the code will be compiled or not, we can disable or enable some compilation warnings, or we can even check for the .NET version and execute different code depending on it.


## Q49.1: What is the preprocessor?

The preprocessor (also known as the “precompiler”) is a program that runs before the actual compiler, that can apply some operations on code before it’s compiled.


## Q49.2: How to disable selected warning in a file?

By using the #pragma warning disable preprocessor directive. It takes the warning code as the parameter, so for example to disable the “Don’t use throw ex” warning we can do “#pragma warning disable CA2200”.


# Q50: What are nullable reference types?

Nullable reference types is a feature introduced with C# 8, that enables explicit declaration of a reference type as nullable or not. The compiler will issue a warning when it recognizes the code in which a non-nullable object has a chance of being null, or when we use nullable reference types without null check, risking the NullReferenceException. This feature doesn’t change the actual way of executing C# code; it only changes the generated warnings.


## Q50.1: What is the default value of non-nullable reference types?

It is null


## Q50.2: What is the purpose of the null-forgiving operator?

It allows us to suppress a compiler warning related to nullability.


## Q50.3: Is it possible to enable or disable compiler warnings related to nullable reference types on the file level? If so, how to do it?

It is possible. We can do it by using ```#nullable enable``` and ```#nullable disable``` preprocessor directives.


# Q51: What is the Common Intermediate Language?

The Common Intermediate Language is a programming language that all .NET-compatible languages like C#, Visual Basic, or F# get compiled to.


## Q51.1: How is it possible that a C# class can derive from, for example, an F# class?

It is possible because both those languages are .NET compatible and they get compiled to the Common Intermediate Language.


## Q51.2: Does C# compiler compile C# source code directly to binary code?

No, it compiles it to the Intermediate Language, which is compiled to binary code by the Just-In-Time compiler in runtime.


## Q51.3: How can you see the CIL code a project got compiled to?

Some tools can decompile a *.dll file and read the CIL code. One of those tools is Ildasm.


## Q51.4: What is the Just-In-Time compiler?

**Just-In-Time** compiler is a feature of the **Common Language Runtime (CLR)**, which translates the **Common Intermediate Language (CIL)** code to binary code during the program execution.


# Q52: What is the Common Language Runtime (CLR)?

The **Common Language Runtime** is a runtime environment that manages the execution of the .NET applications. The **CLR** stands between the actual operating system (for example Windows) and the application.

The CLR is responsible for many operations essential for any .NET application to work. Some of them are:

- **JIT (Just-in-time)** compilation - the compilation of the Common Intermediate Language to the binary code. Thanks to that the .NET applications can be used cross-platform because the code is compiled to platform-specifi c binary code only right before execution.
- **Memory management** - CLR allocates the memory needed for every object created within the application. CLR also includes the Garbage Collector, which is responsible for releasing and defragmenting the memory.
- **Exception handling** - when the exception is thrown, the CLR makes sure the code execution is redirected to the proper catch clause.
- **Thread management** - let's just shortly say that the CLR manages the execution of the multi-threaded applications, making sure all threads work together well
- **Type safety** - part of the CLR is the **CTS - Common Type System**. CTS defines the standard for all .NET-compatible languages. Thanks to that, the CLR can understand types defi ned in C#, F#, Visual Basic, and so on, enabling cross-language integration.

The **CLR** is the implementation of the **CLI** - **Common Language Infrastructure**. **CLI** was originally created by Microsoft and is standardized by **ISO** and **ECMA**.


## Q52.1: What is the diff erence between CLR, CLI, and CIL?

**CLR (Common Language Runtime)** is an implementation of the **CLI (Common Language Infrastructure)**. **CIL is Common Intermediate Language**, to which all .NET-compatible languages get compiled.


## Q52.2: What is the CTS?

**CTS is the Common Type System**, which is a standardized type system for all .NET-compatible languages, which makes them interoperable - for example, we can have a C# class derived from an F# class.


## Q52.3: Is the CLR the only implementation of the CIL?

No. Anyone can create their implementation of the CIL. One of the examples is Mono Runtime.


# Q53: What is the diff erence between value types and reference types?

The differences between value types and reference types are:

1. Value types inherit from **System.ValueType** while reference types inherit from **System.Object**.
2. Value types are passed by copy, reference types are passed by reference.
3. On assignment, a variable of a value type is copied. For reference types, only a reference is copied.
4. All value types are sealed (which means, they cannot be inherited)
5. Value types are stored on the stack, reference types are stored on the heap (because of that, the Garbage Collector only cleans up reference types)
6. The value of the value type variable is cleaned out from the stack when the code execution leaves the scope this variable lived in.


## Q53.1: What will happen if you pass an integer to a method and you increase it by one in the method's body? Will the variable you passed to the method be incremented?

The number will be increased in the scope of the method's body, but the variable outside this method will stay unmodifi ed because a copy was passed to the method.


## Q53.2: Assuming you want the modification to the integer parameter to affect the variable that was passed to a method, how would you achieve that?

By using ref parameter.


# Q54: The in, ref, and out Modifiers

Method parameters have modifiers available to change the desired outcome of how the parameter is treated. **ref**, **out**, and **in** keywords in C# are used to pass arguments within a method or function. They indicate that an argument/parameter is passed by reference.

- **ref** is used to state that the parameter passed **may** be modified by the method
- **in** is used to state that the parameter passed **cannot** be modified by the method.
- **out** is used to state that the parameter passed **must** be modified by the method.


# Q55: What is boxing and unboxing?

**Boxing** is the process of **wrapping** a **value type** into an instance of a type **System.Object**. **Unboxing** is the **opposite** - the process of converting the boxed value back to a value type.


## Q55.1: What is the penalty for using boxing and unboxing?

The main penalty is performance - when boxing, a new object must be created, which involves allocating memory for it. The unboxing requires a cast which is also expensive from the performance point of view.


## Q55.2: Is assigning a string to a variable of type object boxing?

No, because string is not a value type. The point of boxing is to wrap a value type into an object (which is a reference type).


# Q56: What is the diff erence between a class and a struct?

1. Structs are value types and classes are reference types.
2. Structs can only have a constructor with parameters, and all the struct's fields must be assigned in this constructor.
3. Structs can't have explicit parameterless constructors.
4. Structs can't have destructors.


## Q56.1: What is the base type for structs?

System.ValueType


## Q56.2: Is it possible to inherit from a struct?

No, all structs are sealed.


## Q56.3: How would you represent a point in the cartesian coordinate system?

I would create a struct that has two fl oat readonly properties - X and Y.


# Q57: What is LINQ?

LINQ is a set of technologies that allow simple and efficient querying over different kinds of data. Data can be stored in various types of containers - C# data structures like Lists or arrays, databases, XML documents, and many more. LINQ allows us to query such data in a uniform way. We can use different LINQ providers, like **LINQ to SQL** that allows querying over SQL databases, or **LINQ to XML** that allows querying over XML documents. Each **LINQ provider** must **implement** **IQueryProvider** and **IQueryable** interfaces. We can create our own LINQ providers if we need to support querying over a new type of data container.


## Q57.1: What are the benefi ts of using LINQ?

It offers a common syntax for querying any type of data source. It provides a simple yet powerful way of manipulating data. LINQ methods are chainable, which means you can have a single expression with multiple LINQ methods. It allows writing cohesive, readable, and flexible code.


## Q57.2: What is a LINQ provider?

LINQ provider is any class that implements **IQueryProvider** and **IQueryable** interfaces. LINQ providers are used for querying over a particular source of data. Examples of LINQ providers may be LINQ to SQL or LINQ to XML.


# Q58: What are extension methods?

An extension method is a method defined outside a class, that can be called upon this class's objects as a regular member method. Extension methods allow you to add new functionality to a class without modifying it.

Requirements:

- The class in which the extension methods are defi ned must be static and non-generic
- The extension method must take the object of the extended class as a fi rst parameter, with "this" modifi er proceeding this parameter


## Q58.1: How would you add new functionality to an existing class, without modifying this class?

By using extension methods.


## Q58.2: What will happen if you call a member method that has the same signature as the existing extension method?

The member method has priority and it will be the one to be called. The extension method will not be called.


# Q59: What is IEnumerable?

**IEnumerable** is an interface that enables iterating over a collection with a **foreach** loop.

- It allows looping over collections with a foreach loop
- It works with LINQ query expressions
- It allows read-only access to a collection


## Q59.1: What is an enumerator?

An enumerator is a mechanism that allows iterating over collection elements. It's a kind of a pointer that points to a "current" element in the collection.


## Q59.2: Assuming a method returns a collection of some kind, how to best express your intent if you don't want the user to modify this collection?

By returning it as IEnumerable or another readonly collection type.


# Q60: What is the Garbage Collector?

The Garbage Collector is a mechanism that manages the memory used by the application. If an object is no longer used, the Garbage Collector will free the memory it occupies. The Garbage Collector is also responsible for defragmenting the application's memory.

Garbage Collector manages objects that live on the heap, so the reference types (strings, Lists, arrays, and all other objects that are defi ned as classes). Garbage Collector determines if there are any existing references to the object - if not, it decides this object is no longer used and frees the memory used by this object.

So when does the Garbage Collector decide to clean up memory?
- When the system has low physical memory (the operating system notifies about that)
- When the memory that's used by allocated objects on the heap surpasses a given threshold. This threshold is continuously adjusted as the process runs
- When the GC.Collect method is called

The important thing to understand is that **Garbage Collector runs on its own, separate thread**, and as this happens all other threads are being stopped until Garbage Collector finishes its work.

After Garbage Collector fi nishes freeing the memory, it also executes memory defragmentation.

A memory leak is a situation when some piece of memory is not being cleaned up, even if the object using it is no longer in use. It is important to understand that **Garbage Collector does not give us 100% protection from memory leaks**.

One of the most common sources of memory leaks in .NET is related to event handlers.


## Q60.1: Would the Garbage Collector free up the memory occupied by an integer?

No, since an integer is a value type and Garbage Collector only handles memory occupied by reference types. Value types are stored on the stack which has its own mechanism for freeing the memory.


## Q60.2: How to manually trigger the Garbage Collector memory collection?

By calling GC.Collect method from System namespace.


## Q60.3: What is memory fragmentation and defragmentation?

When pieces of memory are allocated and freed, the memory becomes defragmented, which means free memory is in small pieces rather than in one long piece. This is called memory fragmentation. If there is a need to put a big object into memory, it might be impossible to find a block of free memory that is long enough. The process of moving the pieces of allocated memory so they stick together, to create a big chunk of free memory is called defragmentation.


## Q60.4: What are memory leaks? Does the Garbage Collector guarantee protection from them?

Memory leaks happen when memory is not freed even if an object is no longer used. No, GC does not guarantee protection from them.


# Q61: What are nullable types?

Nullable type is any type that can be assigned a value of null. Nullable<T> struct is a wrapper for a value type allowing assigning null to the variable of this type. For example, we can't assign null to an integer, but we can to a variable of type Nullable<int>. **Null represents "lack of value", or "missing value"**. In C#, we can declare value type as nullable with the "?" operator. Using "?" operator is just a short syntax for Nullable<T>.


## Q61.1: Can a value type be assigned null?

No, it can't. It must be wrapped in the Nullable<T> struct first if we want to make it nullable.


## Q61.2: Is it possible to have a variable of type Nullable<T> where T is a reference type? For example, Nullable<string>?

No, the Nullable struct has a type constraint on T that requires the T to be a value type. Providing a reference type as T will result in a compilation error.


# Q62: What are generics?

Generic classes or methods are parametrized by type - like, for example, a List<T> that can store any type of elements. Generics allow us to create classes or methods that are parametrized by type.


## Q62.1: What are type constraints?

Type constraints allow limiting the usage of a generic type only to the types that meet specific criteria. For example, we may require the type to be a value type, or require that this type provides a public parameterless constructor.


## Q62.2: What is the "where" keyword used for?

It's used to define type constraints.


## Q62.3: What are the benefi ts of using generics?

They allow us to reduce code duplication by creating a single class that can work with any type. Reducing code duplication makes the code easier to maintain and less error-prone.


# Q63: What is the diff erence between an interface and an abstract class?

An interface defi nes what set of operations will be provided by any class implementing it - it does not provide any implementation on its own. An abstract class is like a general blueprint for derived classes. It may provide implementations of methods, contain fi elds, etc.

Abstract Part

- An interface is an abstraction over **behavior**. It defines what an object can **do**. When you have a group of objects and they share similar behavior, they might have a common **interface**. For example, a bird, a kite, and a plane fly - so it makes sense for all of them to implement the **IFlyable** interface. When you are given an object implementing **IFlyable** interface, you might not be sure what that **is** - but you'll know it is able to fly. When you try to fi nd what some objects have in common and a **verb** comes to mind, it means you probably want to use an interface.

- An abstract class is an abstraction over **alikeness**. It defines what an object **is**. When you have a group of objects, and they all belong to some general category of things, they might inherit from the same abstract class. For example, a bird, a snake and a dog all are animals - so it makes sense for them to inherit from abstract class Animal. When you are given an object that inherits from the Animal abstract class, you might not be sure how it **behaves** - but you know that it **is** some kind of animal. When you try to find what some objects have in common and a **noun** comes to mind, it means you probably want to use an abstract class.

Technical Part

- An interface is a set of **definitions** of methods - it **does not** provide any implementation (at least in 99% of the cases - see the note about interfaces change in C# 8.0 at the end of this lecture). It specifi es a **contract** that an implementing method will have to fulfill. When you implement an interface in your class, it means you declare that this class will provide all the methods from this interface. For example, one of the most commonly used interfaces in C# is ICollection - an interface that defines a set of methods related to working on collections - methods like Add, Contains, Remove, Clear, etc. ICollection only defines what methods a collection must provide, but they are not implemented in the interface itself. The concrete classes implementing this interface - for example List - provide the implementations.

- An abstract class is a type that is too - well - abstract for the actual instances of it to exist. It represents some general category of things. It can have method implementations, but it can also contain abstract methods - methods with no bodies, that will have to be implemented in the inheriting classes. As in the example before, you can imagine an Animal abstract class. You can't have an object of type Animal - it's always some specific kind of animal, like a dog or a horse. Animal is just an abstraction over a whole category of creatures a bit similar to each other (and not similar at all to plants or fungi).


## Q63.1: Why can't you specify the accessibility modifier for a method defined in the interface?

The point of creating an interface is to specify the public contract that a class implementing it will expose. Modifi ers other than "public" would not make sense. Because of that, the "public" modifi er is the default and we don't need to specify it explicitly.


## Q63.2: Why can't we create instances of abstract classes?

Because an abstract class may have abstract methods which do not contain a body. What would happen if such a method was called? It doesn't have a body so the behavior would be undefined.


# Q64: What is the Bridge design pattern?

The Bridge design pattern allows us to split an inheritance hierarchy into a set of hierarchies. It is the implementation of the "composition over inheritance" principle.

**Bridge design pattern**. Instead of expressing a **trait** of a **base class** as another layer in the inheritance hierarchy, we split the inheritance hierarchy in two. We simply add a **new class for the trait** and then add **inheritors of the trait**. Then, the **base class** will contain a **trait** object within.


## Q64.1 What is "composition over inheritance"?

It is a principle that states that it is better to design polymorphic and reusable code by using composition rather than inheritance.


# Q65: What is the Single Responsibility Principle?

"S" in the SOLID principles stands for Single Responsibility Principle (sometimes referred to as the SRP). This principle states that a class should **be responsible for only one thing**. Sometimes the alternative defi nition is used: that a class **should have no more than one reason to change**.


## Q65.1: How to refactor a class that is known to be breaking the SRP?

One should identify the different responsibilities and move each of them to separate classes. Then the interactions between those classes should be defined, ideally by one class depending on an interface that the other class implements.


# Q66: What is the Open-Closed Principle?

"O" in the SOLID principles stands for Open-Closed Principle (sometimes referred to as the OCP). This principle states that modules, classes, and functions should be **opened for extension, but closed for modification**.


## Q66.1: What are the good reasons to modify a class, disregarding the Open-Closed Principle?"

Firstly, for bug fi xing. Secondly, sometimes sticking to the OCP might be an "overkill" - when it generates huge amounts of super-abstract code that brings more complexity than the OCP reduces.




































