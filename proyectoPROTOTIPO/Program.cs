using System;
using System.Data.SQLite;

class Producto
{
	private string nombre;
	private string presentacion;
	private double precio;
	private string descripcion;
	private string marca;
	private int stock;
	private string unidadStock;
	private string categoria;

	public string Nombre
	{
		get { return nombre; }
		set { nombre = value; }
	}

	public string Presentacion
	{
		get { return presentacion; }
		set { presentacion = value; }
	}

	public double Precio
	{
		get { return precio; }
		set
		{
			if (value > 0)
			{
				precio = value;
			}
		}
	}

	public string Descripcion
	{
		get { return descripcion; }
		set { descripcion = value; }
	}

	public string Marca
	{
		get { return marca; }
		set { marca = value; }
	}

	public int Stock
	{
		get { return stock; }
		set
		{
			if (value >= 0)
			{
				stock = value;
			}
		}
	}

	public string UnidadStock
	{
		get { return unidadStock; }
		set { unidadStock = value; }
	}

	public string Categoria
	{
		get { return categoria; }
		set { categoria = value; }
	}

	public Producto(
		string nombre,
		string presentacion,
		double precio,
		string descripcion,
		string marca,
		int stock,
		string unidadStock,
		string categoria)
	{
		Nombre = nombre;
		Presentacion = presentacion;
		Precio = precio;
		Descripcion = descripcion;
		Marca = marca;
		Stock = stock;
		UnidadStock = unidadStock;
		Categoria = categoria;
	}


}

class Medicamento : Producto
{
	private string sintomas;
	private string enfermedad;
	private string tipo;
	private string principioActivo;
	private string laboratorio;
	private string viaAdministracion;
	private double precioBlister;
	private double precioUnidad;


	public string Sintomas
	{
		get { return sintomas; }
		set { sintomas = value; }
	}

	public string Enfermedad
	{
		get { return enfermedad; }
		set { enfermedad = value; }
	}

	public string Tipo
	{
		get { return tipo; }
		set { tipo = value; }
	}

	public string PrincipioActivo
	{
		get { return principioActivo; }
		set { principioActivo = value; }
	}

	public string Laboratorio
	{
		get { return laboratorio; }
		set { laboratorio = value; }
	}

	public string ViaAdministracion
	{
		get { return viaAdministracion; }
		set { viaAdministracion = value; }
	}

	public double PrecioBlister
	{
		get { return precioBlister; }
		set { precioBlister = value; }
	}

	public double PrecioUnidad
	{
		get { return precioUnidad; }
		set { precioUnidad = value; }
	}

	public Medicamento(
		string nombre,
		string presentacion,
		double precio,
		string descripcion,
		string marca,
		int stock,
		string unidadStock,
		string categoria,
		string sintomas,
		string enfermedad,
		string tipo,
		string principioActivo,
		string laboratorio,
		string viaAdministracion,
		double precioBlister,
		double precioUnidad)
		: base(nombre, presentacion, precio, descripcion, marca, stock, unidadStock, categoria)
	{
		this.sintomas = sintomas;
		this.enfermedad = enfermedad;
		this.tipo = tipo;
		this.principioActivo = principioActivo;
		this.laboratorio = laboratorio;
		this.viaAdministracion = viaAdministracion;
		this.precioBlister = precioBlister;
		this.precioUnidad = precioUnidad;
	}

}

class Suero : Producto
{
	private string sabor;
	private string tipoSuero;

	public string Sabor
	{
		get { return sabor; }
		set { sabor = value; }
	}

	public string TipoSuero
	{
		get { return tipoSuero; }
		set { tipoSuero = value; }
	}

	public Suero(
		string nombre,
		string presentacion,
		double precio,
		string descripcion,
		string marca,
		int stock,
		string unidadStock,
		string categoria,
		string sabor,
		string tipoSuero)
		: base(nombre, presentacion, precio, descripcion, marca, stock, unidadStock, categoria)
	{
		this.sabor = sabor;
		this.tipoSuero = tipoSuero;
	}
}

class ProductoBebe : Producto
{
	private string talla;

	public string Talla
	{
		get { return talla; }
		set { talla = value; }
	}

	public ProductoBebe(
		string nombre,
		string presentacion,
		double precio,
		string descripcion,
		string marca,
		int stock,
		string unidadStock,
		string categoria,
		string talla)
		: base(nombre, presentacion, precio, descripcion, marca, stock, unidadStock, categoria)
	{
		this.talla = talla;
	}

}

class InsumoMedico : Producto
{
	private string uso;

	public string Uso
	{
		get { return uso; }
		set { uso = value; }
	}

	public InsumoMedico(
		string nombre,
		string presentacion,
		double precio,
		string descripcion,
		string marca,
		int stock,
		string unidadStock,
		string categoria,
		string uso)
		: base(nombre, presentacion, precio, descripcion, marca, stock, unidadStock, categoria)
	{
		this.uso = uso;
	}

}

class Higiene : Producto
{
	private string uso;

	public string Uso
	{
		get { return uso; }
		set { uso = value; }
	}

	public Higiene(
		string nombre,
		string presentacion,
		double precio,
		string descripcion,
		string marca,
		int stock,
		string unidadStock,
		string categoria,
		string uso)
		: base(nombre, presentacion, precio, descripcion, marca, stock, unidadStock, categoria)
	{
		this.uso = uso;
	}
}

class SistemaFarmacia
{
	private string conexion = "Data Source=farmacia.db";

	public void CrearTabla()
	{
		using (SQLiteConnection db = new SQLiteConnection(conexion))
		{
			db.Open();

			string sql = @"
            CREATE TABLE IF NOT EXISTS productos(
			id INTEGER PRIMARY KEY AUTOINCREMENT,
			nombre TEXT,
            precio REAL,
			precioBlister REAL,
            precioUnidad REAL,
			descripcion TEXT,
            marca TEXT,
			stock INTEGER,
            unidadStock TEXT,
			categoria TEXT,
			presentacion TEXT,
            sintomas TEXT,
            enfermedad TEXT,
            tipo TEXT,
            principioActivo TEXT,
            laboratorio TEXT,
            viaAdministracion TEXT,
			sabor TEXT,
            tipoSuero TEXT,
			talla TEXT,
			uso TEXT
			);";

			SQLiteCommand comando = new SQLiteCommand(sql, db);

			comando.ExecuteNonQuery();

			Console.WriteLine("Base de datos y tabla creadas");
		}
	}

	public void Agregar(Producto producto)
	{
		using (SQLiteConnection db = new SQLiteConnection(conexion))
		{
			db.Open();

			string sql =
			"INSERT INTO productos " +
			"(nombre,precio,precioBlister,precioUnidad," +
			"descripcion,marca,stock,unidadStock,categoria," +
			"presentacion,sintomas,enfermedad,tipo," +
			"principioActivo,laboratorio,viaAdministracion," +
			"sabor,tipoSuero,talla,uso) " +

			"VALUES " +
			"(@nombre,@precio,@precioBlister,@precioUnidad," +
			"@descripcion,@marca,@stock,@unidadStock,@categoria," +
			"@presentacion,@sintomas,@enfermedad,@tipo," +
			"@principioActivo,@laboratorio,@viaAdministracion," +
			"@sabor,@tipoSuero,@talla,@uso)";

			SQLiteCommand comando = new SQLiteCommand(sql, db);

			comando.Parameters.AddWithValue("@nombre", producto.Nombre);

			comando.Parameters.AddWithValue("@presentacion", producto.Presentacion);

			comando.Parameters.AddWithValue("@precio", producto.Precio);

			comando.Parameters.AddWithValue("@descripcion", producto.Descripcion);

			comando.Parameters.AddWithValue("@marca", producto.Marca);

			comando.Parameters.AddWithValue("@stock", producto.Stock);

			comando.Parameters.AddWithValue("@unidadStock", producto.UnidadStock);

			comando.Parameters.AddWithValue("@categoria", producto.Categoria);

			comando.Parameters.AddWithValue("@precioBlister", 0);

			comando.Parameters.AddWithValue("@precioUnidad", 0);

			comando.Parameters.AddWithValue("@sintomas", "");

			comando.Parameters.AddWithValue("@enfermedad", "");

			comando.Parameters.AddWithValue("@tipo", "");

			comando.Parameters.AddWithValue("@principioActivo", "");

			comando.Parameters.AddWithValue("@laboratorio", "");

			comando.Parameters.AddWithValue("@viaAdministracion", "");

			comando.Parameters.AddWithValue("@sabor", "");

			comando.Parameters.AddWithValue("@tipoSuero", "");

			comando.Parameters.AddWithValue("@talla", "");

			comando.Parameters.AddWithValue("@uso", "");

			if (producto is Medicamento med)
			{
				comando.Parameters["@precioBlister"].Value = med.PrecioBlister;

				comando.Parameters["@precioUnidad"].Value = med.PrecioUnidad;

				comando.Parameters["@sintomas"].Value = med.Sintomas;

				comando.Parameters["@enfermedad"].Value = med.Enfermedad;

				comando.Parameters["@tipo"].Value = med.Tipo;

				comando.Parameters["@principioActivo"].Value = med.PrincipioActivo;

				comando.Parameters["@laboratorio"].Value = med.Laboratorio;

				comando.Parameters["@viaAdministracion"].Value = med.ViaAdministracion;
			}

			else if (producto is Suero suero)
			{
				comando.Parameters["@sabor"].Value = suero.Sabor;

				comando.Parameters["@tipoSuero"].Value = suero.TipoSuero;
			}

			else if (producto is ProductoBebe bebe)
			{
				comando.Parameters["@talla"].Value = bebe.Talla;
			}

			else if (producto is InsumoMedico insumo)
			{
				comando.Parameters["@uso"].Value = insumo.Uso;
			}

			else if (producto is Higiene higiene)
			{
				comando.Parameters["@uso"].Value = higiene.Uso;
			}

			comando.ExecuteNonQuery();

			Console.WriteLine("Producto agregado");
		}
	}

	private void MostrarProducto(SQLiteDataReader lector)
	{
		string categoria = lector["categoria"].ToString();

		Console.WriteLine("\nID: " + lector["id"]);

		Console.WriteLine("Nombre: " + lector["nombre"]);

		Console.WriteLine("Presentacion: " + lector["presentacion"]);

		if (categoria == "Medicamento")
		{
			if (Convert.ToDouble(lector["precioBlister"]) > 0)
			{
				Console.WriteLine("Precio Blister: Q" + lector["precioBlister"]);

				Console.WriteLine("Precio Unidad: Q" + lector["precioUnidad"]);
			}
			else
			{
				Console.WriteLine("Precio: Q" + lector["precio"]);
			}
		}
		else
		{
			Console.WriteLine("Precio: Q" + lector["precio"]);
		}

		Console.WriteLine("Descripcion: " + lector["descripcion"]);

		Console.WriteLine("Marca: " + lector["marca"]);

		Console.WriteLine("Categoria: " + categoria);

		if (categoria == "Medicamento")
		{
			Console.WriteLine("Sintomas: " + lector["sintomas"]);

			Console.WriteLine("Enfermedad: " + lector["enfermedad"]);

			Console.WriteLine("Tipo: " + lector["tipo"]);

			Console.WriteLine("Principio Activo: " + lector["principioActivo"]);

			Console.WriteLine("Laboratorio: " + lector["laboratorio"]);

			Console.WriteLine("Via Administracion: " + lector["viaAdministracion"]);
		}
		else if (categoria == "Suero")
		{
			Console.WriteLine("Sabor: " + lector["sabor"]);

			Console.WriteLine("Tipo: " + lector["tipoSuero"]);
		}
		else if (categoria == "ProductoBebe")
		{
			if (!string.IsNullOrWhiteSpace(lector["talla"].ToString()))
			{
				Console.WriteLine("Talla: " + lector["talla"]);
			}
		}
		else if (categoria == "InsumoMedico")
		{
			Console.WriteLine("Uso: " + lector["uso"]);
		}
		else if (categoria == "Higiene")
		{
			Console.WriteLine("Uso: " + lector["uso"]);
		}

		Console.WriteLine("Stock: " + lector["stock"] + " " + lector["unidadStock"]);

		Console.WriteLine("\n------------------------");
	}
	public void Mostrar()
	{
		using (SQLiteConnection db = new SQLiteConnection(conexion))
		{
			db.Open();

			string sql = "SELECT * FROM productos";

			SQLiteCommand comando = new SQLiteCommand(sql, db);

			SQLiteDataReader lector = comando.ExecuteReader();

			Console.WriteLine();
			Console.WriteLine("===== PRODUCTOS =====");
			while (lector.Read())
			{
				MostrarProducto(lector);
			}
		}
	}

	public void Buscar(string palabra)
	{
		using (SQLiteConnection db = new SQLiteConnection(conexion))
		{
			db.Open();

			string sql =
			"SELECT * FROM productos " +
			"WHERE nombre LIKE @palabra " +
			"OR descripcion LIKE @palabra " +
			"OR marca LIKE @palabra " +
			"OR categoria LIKE @palabra " +
			"OR presentacion LIKE @palabra " +
			"OR sintomas LIKE @palabra " +
			"OR enfermedad LIKE @palabra " +
			"OR tipo LIKE @palabra " +
			"OR principioActivo LIKE @palabra " +
			"OR laboratorio LIKE @palabra " +
			"OR viaAdministracion LIKE @palabra " +
			"OR tipoSuero LIKE @palabra " +
			"OR talla LIKE @palabra " +
			"OR uso LIKE @palabra " +
			"OR unidadStock LIKE @palabra";

			SQLiteCommand comando = new SQLiteCommand(sql, db);

			comando.Parameters.AddWithValue("@palabra", "%" + palabra + "%");

			SQLiteDataReader lector = comando.ExecuteReader();

			bool encontrado = false;


			while (lector.Read())
			{
				encontrado = true;
				MostrarProducto(lector);
			}

			if (!encontrado)
			{
				Console.WriteLine("No se encontraron coincidencias");
			}
		}
	}

	public void Eliminar(int id)
	{
		using (SQLiteConnection db = new SQLiteConnection(conexion))
		{
			db.Open();

			string sql = "DELETE FROM productos " + "WHERE id=@id";

			SQLiteCommand comando = new SQLiteCommand(sql, db);

			comando.Parameters.AddWithValue("@id", id);

			int filas = comando.ExecuteNonQuery();

			if (filas > 0)
			{
				Console.WriteLine("Producto eliminado");
			}
			else
			{
				Console.WriteLine("ID no encontrado");
			}
		}
	}

	public void ModificarStock(int id, int stock)
	{
		using (SQLiteConnection db = new SQLiteConnection(conexion))
		{
			db.Open();

			string sql =
			"UPDATE productos " +
			"SET stock=@stock " +
			"WHERE id=@id";

			SQLiteCommand comando = new SQLiteCommand(sql, db);

			comando.Parameters.AddWithValue("@stock", stock);

			comando.Parameters.AddWithValue("@id", id);

			int filas = comando.ExecuteNonQuery();

			if (filas > 0)
			{
				Console.WriteLine("Stock modificado");
			}
			else
			{
				Console.WriteLine("ID no encontrado");
			}
		}
	}
	public void ModificarPrecio(int id, double precio)
	{
		using (SQLiteConnection db = new SQLiteConnection(conexion))
		{
			db.Open();

			string sql =
			"UPDATE productos " +
			"SET precio=@precio " +
			"WHERE id=@id";

			SQLiteCommand comando = new SQLiteCommand(sql, db);

			comando.Parameters.AddWithValue("@precio", precio);

			comando.Parameters.AddWithValue("@id", id);

			int filas = comando.ExecuteNonQuery();

			if (filas > 0)
			{
				Console.WriteLine("Precio modificado");
			}
			else
			{
				Console.WriteLine("ID no encontrado");
			}
		}
	}

	public void ModificarPrecioBlister(int id, double precioBlister, double precioUnidad)
	{
		using (SQLiteConnection db = new SQLiteConnection(conexion))
		{
			db.Open();

			string sql =
			"UPDATE productos " +
			"SET precioBlister=@precioBlister, " +
			"precioUnidad=@precioUnidad, " +
			"precio=@precioBlister " +
			"WHERE id=@id";

			SQLiteCommand comando = new SQLiteCommand(sql, db);

			comando.Parameters.AddWithValue("@precioBlister", precioBlister);

			comando.Parameters.AddWithValue("@precioUnidad", precioUnidad);

			comando.Parameters.AddWithValue("@id", id);

			int filas = comando.ExecuteNonQuery();

			if (filas > 0)
			{
				Console.WriteLine("Precios modificados");
			}
			else
			{
				Console.WriteLine("ID no encontrado");
			}
		}
	}

	public void ModificarSabor(int id, string sabor)
	{
		using (SQLiteConnection db = new SQLiteConnection(conexion))
		{
			db.Open();

			string sql =
			"UPDATE productos " +
			"SET sabor=@sabor " +
			"WHERE id=@id";

			SQLiteCommand comando = new SQLiteCommand(sql, db);

			comando.Parameters.AddWithValue("@sabor", sabor);

			comando.Parameters.AddWithValue("@id", id);

			int filas = comando.ExecuteNonQuery();

			if (filas > 0)
			{
				Console.WriteLine("Sabor modificado");
			}
			else
			{
				Console.WriteLine("ID no encontrado");
			}
		}
	}

	public void ModificarTalla(int id, string talla)
	{
		using (SQLiteConnection db = new SQLiteConnection(conexion))
		{
			db.Open();

			string sql =
			"UPDATE productos " +
			"SET talla=@talla " +
			"WHERE id=@id";

			SQLiteCommand comando = new SQLiteCommand(sql, db);

			comando.Parameters.AddWithValue("@talla", talla);

			comando.Parameters.AddWithValue("@id", id);

			int filas = comando.ExecuteNonQuery();

			if (filas > 0)
			{
				Console.WriteLine("Talla modificada");
			}
			else
			{
				Console.WriteLine("ID no encontrado");
			}
		}
	}

	public void ModificarUso(int id, string uso)
	{
		using (SQLiteConnection db = new SQLiteConnection(conexion))
		{
			db.Open();
			string sql =
			"UPDATE productos " +
			"SET uso=@uso " +
			"WHERE id=@id";

			SQLiteCommand comando = new SQLiteCommand(sql, db);

			comando.Parameters.AddWithValue("@uso", uso);

			comando.Parameters.AddWithValue("@id", id);

			int filas = comando.ExecuteNonQuery();

			if (filas > 0)
			{
				Console.WriteLine("Uso modificado");
			}
			else
			{
				Console.WriteLine("ID no encontrado");
			}
		}
	}

}

class Program
{
	static void Main()
	{
		SistemaFarmacia obj = new SistemaFarmacia();

		obj.CrearTabla();

		int opcion;
		bool correcto;

		do
		{
			do
			{
				Console.Clear();
				Console.WriteLine("===== MENU =====");

				Console.WriteLine("1- Agregar Producto");

				Console.WriteLine("2- Mostrar Productos");

				Console.WriteLine("3- Buscar Producto");

				Console.WriteLine("4- Modificar Producto");

				Console.WriteLine("5- Eliminar Producto");

				Console.WriteLine("6- Salir");

				Console.Write("Seleccione una opcion: ");

				correcto = int.TryParse(Console.ReadLine(), out opcion);

				if (opcion < 1 || opcion > 6)
				{
					correcto = false;
					Console.WriteLine("Opcion invalida intentelo nuevamente");
					Console.ReadKey();
				}

			} while (!correcto);

			Console.Clear();

			switch (opcion)
			{
				case 1:
					{
						string nombre;
						do
						{
							Console.Write("Nombre: ");
							nombre = Console.ReadLine();

							if (string.IsNullOrWhiteSpace(nombre))
							{
								Console.WriteLine("No puede quedar vacio");
								Console.WriteLine("Intentelo de nuevo");
							}

						} while (string.IsNullOrWhiteSpace(nombre));

						string presentacion = "";

						int opcionPresentacion;

						do
						{
							Console.WriteLine();
							Console.WriteLine("Presentacion: ");

							Console.WriteLine("1- Tableta");

							Console.WriteLine("2- Capsula");

							Console.WriteLine("3- Pastilla");

							Console.WriteLine("4- Blister");

							Console.WriteLine("5- Capsula Gel");

							Console.WriteLine("6- Jarabe");

							Console.WriteLine("7- Inyeccion");

							Console.WriteLine("8- Crema");

							Console.WriteLine("9- Gotas");

							Console.WriteLine("10- Sobre");

							Console.WriteLine("11- Hidratante");

							Console.WriteLine("12- Toallas Humedas");

							Console.WriteLine("13- Pañal");

							Console.WriteLine("14- Jeringa");

							Console.WriteLine("15- Gasas");

							Console.WriteLine("16- Vendas");

							Console.WriteLine("17- Otro");

							Console.Write("Seleccione el tipo de presentacion del producto: ");

							correcto = int.TryParse(Console.ReadLine(), out opcionPresentacion);

							switch (opcionPresentacion)
							{
								case 1:
									presentacion = "Tableta";
									break;

								case 2:
									presentacion = "Capsula";
									break;

								case 3:
									presentacion = "Pastilla";
									break;

								case 4:
									presentacion = "Blister";
									break;

								case 5:
									presentacion = "Capsula Gel";
									break;

								case 6:
									presentacion = "Jarabe";
									break;

								case 7:
									presentacion = "Inyeccion";
									break;

								case 8:
									presentacion = "Crema";
									break;

								case 9:
									presentacion = "Gota";
									break;

								case 10:
									presentacion = "Sobre";
									break;

								case 11:
									presentacion = "Hidratante";
									break;

								case 12:
									presentacion = "Toallas Humedas";
									break;

								case 13:
									presentacion = "Pañal";
									break;

								case 14:
									presentacion = "Jeringa";
									break;

								case 15:
									presentacion = "Gasas";
									break;

								case 16:
									presentacion = "Vendas";
									break;

								case 17:
									{
										do
										{
											Console.Write("Ingrese la presentacion: ");
											presentacion = Console.ReadLine();

											if (string.IsNullOrWhiteSpace(presentacion))
											{
												Console.WriteLine("Dato invalido, intentelo otra vez");
											}

										} while (string.IsNullOrWhiteSpace(presentacion));
									}
									break;

								default:
									correcto = false;
									Console.WriteLine("Opcion invalida intentelo otra vez");
									break;
							}
						} while (!correcto);

						double precio = 0;

						double precioBlister = 0;

						double precioUnidad = 0;

						if (presentacion == "Tableta" || presentacion == "Capsula" || presentacion == "Pastilla" || presentacion == "Blister" || presentacion == "Capsula Gel")
						{
							do
							{
								Console.Write("Precio Blister: ");
								correcto = double.TryParse(Console.ReadLine(), out precioBlister);
								if (precioBlister <= 0)
								{
									correcto = false;
								}
							} while (!correcto);

							do
							{
								Console.Write("Precio Unidad: ");
								correcto = double.TryParse(Console.ReadLine(), out precioUnidad);
								if (precioUnidad <= 0)
								{
									correcto = false;
								}
							} while (!correcto);

							precio = precioBlister;
						}
						else
						{
							do
							{
								Console.Write("Precio: ");
								correcto = double.TryParse(Console.ReadLine(), out precio);
								if (precio <= 0)
								{
									correcto = false;
									Console.WriteLine("Precio invalido ingreselo nuevamente");
								}
							} while (!correcto);
						}
						string descripcion;
						do
						{
							Console.Write("Descripcion: ");
							descripcion = Console.ReadLine();
							if (string.IsNullOrWhiteSpace(descripcion))
							{
								Console.WriteLine("No puede quedar vacio vuelva a ingresar");
							}
						} while (string.IsNullOrWhiteSpace(descripcion));

						string marca;

						do
						{
							Console.Write("Marca: ");
							marca = Console.ReadLine();
							if (string.IsNullOrWhiteSpace(marca))
							{
								Console.WriteLine("No puede quedar vacio vuelva a ingresar");
							}
						} while (string.IsNullOrWhiteSpace(marca));

						int stock;

						do
						{
							Console.Write("Stock: ");
							correcto = int.TryParse(Console.ReadLine(), out stock);
							if (stock < 0)
							{
								correcto = false;
								Console.WriteLine("Stock invalido vuelva a intentarlo");
							}

						} while (!correcto);

						string unidadStock = "";

						int opcionUnidad;

						do
						{
							Console.WriteLine();
							Console.WriteLine("Unidad de Stock");

							Console.WriteLine("1- Unidad");

							Console.WriteLine("2- Caja");

							Console.WriteLine("3- Blister");

							Console.WriteLine("4- Paquete");

							Console.WriteLine("5- Botella");

							Console.WriteLine("6- Sobre");

							Console.Write("Seleccione una opcion: ");

							correcto = int.TryParse(Console.ReadLine(), out opcionUnidad);

							switch (opcionUnidad)
							{
								case 1:
									unidadStock = "Unidad/es";
									break;

								case 2:
									unidadStock = "Caja/s";
									break;

								case 3:
									unidadStock = "Blister/s";
									break;

								case 4:
									unidadStock = "Paquete/s";
									break;

								case 5:
									unidadStock = "Botella/s";
									break;

								case 6:
									unidadStock = "Sobre/s";
									break;

								default:
									correcto = false;
									Console.WriteLine("Opcion invalida intentelo otra vez");
									break;
							}

						} while (!correcto);

						string categoria = "";

						int opcionCategoria;
						do
						{
							Console.WriteLine();
							Console.WriteLine("Categorias");

							Console.WriteLine("1- Medicamento");

							Console.WriteLine("2- Suero");

							Console.WriteLine("3- Producto Bebe");

							Console.WriteLine("4- Insumo Medico");

							Console.WriteLine("5- Higiene");

							Console.Write("Seleccione una categoria: ");

							correcto = int.TryParse(Console.ReadLine(), out opcionCategoria);

							switch (opcionCategoria)
							{
								case 1:
									categoria = "Medicamento";
									break;

								case 2:
									categoria = "Suero";
									break;

								case 3:
									categoria = "ProductoBebe";
									break;

								case 4:
									categoria = "InsumoMedico";
									break;

								case 5:
									categoria = "Higiene";
									break;

								default:
									correcto = false;
									Console.WriteLine("Opcion invalida");
									break;
							}
						} while (!correcto);

						if (categoria == "Medicamento")
						{
							string sintomas;
							string enfermedad;
							string tipo;
							string principioActivo;
							string laboratorio;
							string viaAdministracion;

							do
							{
								Console.Write("Sintomas: ");
								sintomas = Console.ReadLine();
								if (string.IsNullOrWhiteSpace(sintomas))
								{
									Console.WriteLine("No puede quedar vacio");
								}
							} while (string.IsNullOrWhiteSpace(sintomas));

							do
							{
								Console.Write("Enfermedad: ");
								enfermedad = Console.ReadLine();
								if (string.IsNullOrWhiteSpace(enfermedad))
								{
									Console.WriteLine("No puede quedar vacio vuelva a intentar");
								}
							} while (string.IsNullOrWhiteSpace(enfermedad));

							do
							{
								Console.Write("Tipo: ");
								tipo = Console.ReadLine();
								if (string.IsNullOrWhiteSpace(tipo))
								{
									Console.WriteLine("No puede quedar vacio vuelva a intentar");
								}
							} while (string.IsNullOrWhiteSpace(tipo));

							do
							{
								Console.Write("Principio Activo: ");
								principioActivo = Console.ReadLine();

								if (string.IsNullOrWhiteSpace(principioActivo))
								{
									Console.WriteLine("No puede quedar vacio vuelva a intentar");
								}
							} while (string.IsNullOrWhiteSpace(principioActivo));

							do
							{
								Console.Write("Laboratorio: ");
								laboratorio = Console.ReadLine();

								if (string.IsNullOrWhiteSpace(laboratorio))
								{
									Console.WriteLine("No puede quedar vacio vuelva a intentar");
								}
							} while (string.IsNullOrWhiteSpace(laboratorio));

							do
							{
								Console.Write("Via Administracion: ");
								viaAdministracion = Console.ReadLine();

								if (string.IsNullOrWhiteSpace(viaAdministracion))
								{
									Console.WriteLine("No puede quedar vacio  vuelva a intentar");
								}

							} while (string.IsNullOrWhiteSpace(viaAdministracion));

							Medicamento med = new Medicamento(
							nombre, presentacion, precio, descripcion, marca, stock, unidadStock, categoria,
							 sintomas, enfermedad, tipo, principioActivo, laboratorio, viaAdministracion,
							precioBlister, precioUnidad);

							obj.Agregar(med);
						}

						else if (categoria == "Suero")
						{
							string sabor;
							string tipoSuero;

							do
							{
								Console.Write("Sabor: ");
								sabor = Console.ReadLine();
								if (string.IsNullOrWhiteSpace(sabor))
								{
									Console.WriteLine("No puede quedar vacio intente nuevamente");
								}
							} while (string.IsNullOrWhiteSpace(sabor));

							do
							{
								Console.Write("Tipo: ");
								tipoSuero = Console.ReadLine();
								if (string.IsNullOrWhiteSpace(tipoSuero))
								{
									Console.WriteLine("No puede quedar vacio intente nuevamente");
								}
							} while (string.IsNullOrWhiteSpace(tipoSuero));

							Suero suero = new Suero(nombre, presentacion, precio, descripcion, marca, stock, unidadStock, categoria, sabor, tipoSuero);
							obj.Agregar(suero);
						}

							else if (categoria == "ProductoBebe")
							{
								string talla = "";

								if (presentacion == "Pañal")
								{
									do
									{
										Console.Write("Talla: ");
										talla = Console.ReadLine();

										if (string.IsNullOrWhiteSpace(talla))
										{
											Console.WriteLine("No puede quedar vacio");
										}

									} while (string.IsNullOrWhiteSpace(talla));
								}

							ProductoBebe bebe = new ProductoBebe(nombre, presentacion, precio, descripcion, marca, stock, unidadStock, categoria, talla);
							obj.Agregar(bebe);
						}
					
						else if (categoria == "InsumoMedico")
						{
							string uso;
							do
							{
								Console.Write("Uso: ");
								uso = Console.ReadLine();
								if (string.IsNullOrWhiteSpace(uso))
								{
									Console.WriteLine("No puede quedar vacio intente nuevamente");
								}
							} while (string.IsNullOrWhiteSpace(uso));

							InsumoMedico insumo = new InsumoMedico(nombre, presentacion, precio, descripcion, marca, stock, unidadStock, categoria, uso);
							obj.Agregar(insumo);
						}

						else if (categoria == "Higiene")
						{
							string uso;
							do
							{
								Console.Write("Uso: ");
								uso = Console.ReadLine();
								if (string.IsNullOrWhiteSpace(uso))
								{
									Console.WriteLine("No puede quedar vacio intente nuevamente");
								}
							} while (string.IsNullOrWhiteSpace(uso));

							Higiene higiene = new Higiene(nombre, presentacion, precio, descripcion, marca, stock, unidadStock, categoria, uso);
							obj.Agregar(higiene);
						}
						Console.ReadKey();
					}
					break;

				case 2:
					{
						obj.Mostrar();
						Console.ReadKey();
					}
					break;

				case 3:
					{
						string palabra;
						do
						{
							Console.Write("Ingrese palabra a buscar: ");
							palabra = Console.ReadLine();

							if (string.IsNullOrWhiteSpace(palabra))
							{
								Console.WriteLine("No puede quedar vacio");
							}

						} while (string.IsNullOrWhiteSpace(palabra));

						obj.Buscar(palabra);

						Console.ReadKey();
					}
					break;

				case 4:
					{
						int idModificar;
						do
						{
							Console.Write("Ingrese ID: ");
							correcto = int.TryParse(Console.ReadLine(), out idModificar);

							if (idModificar <= 0)
							{
								correcto = false;
								Console.WriteLine("ID invalido");
							}

						} while (!correcto);

						int opcionModificar;

						do
						{
							Console.WriteLine();
							Console.WriteLine("1- Modificar Stock");

							Console.WriteLine("2- Modificar Precio");

							Console.WriteLine("3- Modificar Precio Blister");

							Console.WriteLine("4- Modificar Sabor");

							Console.WriteLine("5- Modificar Talla");

							Console.WriteLine("6- Modificar Uso");

							Console.Write("Seleccione una opcion: ");

							correcto = int.TryParse(Console.ReadLine(), out opcionModificar);

							if (opcionModificar < 1 || opcionModificar > 6)
							{
								correcto = false;
								Console.WriteLine("Opcion invalida");
							}
						} while (!correcto);

						if (opcionModificar == 1)
						{
							int stock;

							do
							{
								Console.Write("Nuevo stock: ");
								correcto = int.TryParse(Console.ReadLine(), out stock);

								if (stock < 0)
								{
									correcto = false;
									Console.WriteLine("Stock invalido");
								}

							} while (!correcto);

							obj.ModificarStock(idModificar, stock);

						}
						else if (opcionModificar == 2)
						{
							double precio;
							do
							{
								Console.Write("Nuevo precio: ");
								correcto = double.TryParse(Console.ReadLine(), out precio);
								if (precio <= 0)
								{
									correcto = false;
									Console.WriteLine("Precio invalido");
								}
							} while (!correcto);

							obj.ModificarPrecio(idModificar, precio);
						}
						else if (opcionModificar == 3)
						{
							double precioBlister;
							double precioUnidad;
							do
							{
								Console.Write("Precio blister: ");
								correcto = double.TryParse(Console.ReadLine(), out precioBlister);
								if (precioBlister <= 0)
								{
									correcto = false;
								}
							} while (!correcto);

							do
							{
								Console.Write("Precio unidad: ");
								correcto = double.TryParse(Console.ReadLine(), out precioUnidad);
								if (precioUnidad <= 0)
								{
									correcto = false;
								}
							} while (!correcto);

							obj.ModificarPrecioBlister(idModificar, precioBlister, precioUnidad);
						}

						else if (opcionModificar == 4)
						{
							string sabor;
							do
							{
								Console.Write("Sabor: ");
								sabor = Console.ReadLine();
							} while (string.IsNullOrWhiteSpace(sabor));

							obj.ModificarSabor(idModificar, sabor);
						}

						else if (opcionModificar == 5)
						{
							string talla;
							do
							{
								Console.Write("Talla: ");
								talla = Console.ReadLine();

							} while (string.IsNullOrWhiteSpace(talla));

							obj.ModificarTalla(idModificar, talla);
						}

						else if (opcionModificar == 6)
						{
							string uso;
							do
							{
								Console.Write("Uso: ");
								uso = Console.ReadLine();

							} while (string.IsNullOrWhiteSpace(uso));

							obj.ModificarUso(idModificar, uso);
						}
						Console.ReadKey();
					}
					break;

				case 5:
					{
						int idEliminar;
						do
						{
							Console.Write("Ingrese ID: ");
							correcto = int.TryParse(Console.ReadLine(), out idEliminar);

							if (idEliminar <= 0)
							{
								correcto = false;
								Console.WriteLine("ID invalido");
							}
						} while (!correcto);

						obj.Eliminar(idEliminar);

						Console.ReadKey();
					}
					break;

				case 6:
					{
						Console.WriteLine("Saliendo del programa....");
						Console.ReadKey();
					}
					break;
			}
		} while (opcion != 6);
	}
}
