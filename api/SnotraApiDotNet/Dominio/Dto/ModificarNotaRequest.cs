public sealed record ModificarNotaRequest(
    string Caminho,
    string Texto,
    string[] Urls
);