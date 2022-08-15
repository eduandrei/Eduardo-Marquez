using Proyecto_final.ADO.NET;
{
    static void Main(string[] args)
    {
        ProductoHandler productoHandler = new ProductoHandler();

        productoHandler.GetProductos();


        UsuarioHandler usuarioHandler = new UsuarioHandler();

        usuarioHandler.GetUsuarios();
    }
}
}