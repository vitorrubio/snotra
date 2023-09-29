public sealed record CriarNotaRequest(
    string Caminho,
    string Texto,
    string[] Urls
);