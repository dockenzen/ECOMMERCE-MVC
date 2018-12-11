# ECOMMERCE-MVC

Restante

Agregar a stock maximo y minimo. Ivan
	Implica modificar la base y modificar la vista de editar producto que modifique la tabla stock.
	Mostrar la sucursal a la que pertenece el producto que esta siendo modificado.

Notificacion de alerta minimo stock
	Si el stock de alguno de los productos existentes es menor al minimo mostrar el mensaje
              “Existen productos que están por debajo del limite minimo de stock”

Poder penalizar al usuario 

Todos los abm 

Manejo de stock.

Lo ultimo Los 3 tipos de usuario. Alta de vendedor.

Todos los estados de la orden

Poder generar la orden de compra

Medios de pago 

Bancos Tarjetas  

Promos – Cupones.

Lo Ultimo Efectivo 

Manejo de usuarios 

ABM nuevos productos.

Estadisticas de pedidos pendientes, usuarios clientes on, listar ordenes según estado, stock que faltan. Ivan.


ShopCheckoutStep1
	Si selecciona metodo de entrega Retira en sucursal, muestra las sucursales disponibles para seleccionar.
	Si selecciona metodo de entrega Envio a domicilio, muestra los campos de direccion a completar.

	Si checkea Usar datos de contacto se completa con la data del usuario actual
	Si no checkea Usar datos de contacto se completa y valida que ingrese los datos
	
	Metodo de pago
		Si es efectivo, genera una factura codigo de barra sarasa
		Si es tarjeta, muestra los campos de la tarjeta a cargar y los valida
