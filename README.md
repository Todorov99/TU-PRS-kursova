# Build binary

Get inside the Files directory with the source files of the project. Run:

```
dotnet publish --self-contained -r osx-x64 -c release -o ./test  -p:PublishSingleFile=true

```

# Run bainary

```
./test/Files
```