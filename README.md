# Encompass Abstractions

This codebase is more of a Proof of Concept to work out if it is possible to unit test an Encompass plugin or how practical that sort of thing could even be. The approach is to generate interfaces and a wrapper class per type then use those throughout the codebase allowing the plugin logic to be verified initially through unit tests.

The current issue I feel exists is that unit tests end up being fairly verbose when using something like moq. Though this could just come from my limited use with moq. You could most likely have a standard setup for each test and use that. Maybe another library like nsubstitute would be less verbose. I also would want to look into creating fake classes for each interface and then using those testing classes directly. An example that exist already is the "FakeLoanField" class.

Another caveat is that it may have a substantial perf hit. I think this is unlikely but havent tested it yet. It maybe be worth the time saved from testing.

# Abstraction Generator

This does the meat and potatoes work. Since I generally dont need every type Encompass provides I decided to make the generator take a list of type and just generate abstraction for those types and any other types they depend on (in theory though not sure that is working correctly right now). This keeps the library smaller though i am not sure if including all types in prohibitively large. All the required class data is pulled in with reflection through the help of the fasterflect library and then put together with StringBuilder.

The generator could also be cleaned up more, kinda spaghetti right now, but I am tired and the POC works.

# Sample

This is a very simple plugin that I will probably add onto at some point. Currently, everything is started in the Pluginhost file. My thought is what is the point of doing all this abstraction if we are not using DI as well. Though it is kinda required to be able to test easily.

I also havent thought through the plugin base class all too much. My initial thought was it would be cool to be able to activate and deactive certain plugins in case an issue arose with one of them. Activate is where you would add the initial setup and then deactivate would unsubscribe from all event to be in an inactive state.

# Sample Tests

I think these tests are pretty rough looking but get across the point. I would like to duplicate some of the tests showing different ways of testing and see which one feels best. The Fake classes might also just be moved to its own library if they end up being more ergonomic. I generally dislike mocking frameworks.
