   M S B A M L   `   `   `  ���� F  BREPORTE WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:REPORTE_WPFREPORTE_WPF      REPORTE_WPF.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:REPORTE_WPF       � Title$"  PDV - Reporte de Proveedores��$	��461��$	��900��   AppIcon � Icon# [  .��� -    �Name$ frm_main��$��0,0,0,0q�.+��  � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $��* �.+�� $��50,25,50,10q�$��0�� �� $
��Auto ��� $��* �.+��� -    ��Name$ lbl_proveedores��$��Poveedores:��$
��Left=�$	��Top=�$��0���� -    ��Name$ cb_proveedores��$	��Top=� �� SelectedIndex$ 0��$��1��$��Stretch=����� .R��� .+��� ���� *nombre+��  �� Orientation$ 
Horizontal=�$��50,10,20,10q�$��1��$��Center=�.+��� -   $ 	lbl_desde��$��Desde��$��Center=�$��
0,0, 30, 0q�(  "System.Windows.Controls.DatePicker  -   	  Name$	 dp_desde��$��Center=�$��0,0,50,0q��� -   $ 	lbl_hasta��$��Hasta��$��0,0,30,0q�$��Center=�  -   $	 dp_hasta��$��Center=�$��0,0,50,0q��� -   
 ��Name$
 
cb_filtrar��$��Filtrar por fecha��$��Center=�$��0,0,0,0q�$��2��$��Center=�� $��0,0,0,0q�$��3�� �� $
��Auto �$	��200���� .+�� $��0�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -	   $ 
lbl_buscar��$ ��Buscar (Código o nombre):��$��0��$��
10, 10,0,0q��� -
    ��Name$ tb_buscarProd��$��1��$��Stretch=�$��	10,0,10,0q� �� TextWrapping$
 Wrap=�$	��Top=�$
��Auto��$��16(��� $��
Productos:��$��2��$��	10,0,10,0q��� -    ��Name$ lb_prod_proov��$��Stretch=�$��Stretch=�$��
10,0,10,10q�$��3������ .R��  �� $��* �.+��� $��0������ *nombre+� $��1�� �� $
��Auto ��� $��* ��� $
��Auto �.+��� -   $ 
lbl_header��$��Historial de Movimientos��$��0��$��10,10,10, 0q�$��16(�&   System.Windows.Controls.DataGrid  -     Name$ dg_historial��$��	10,0,10,0q�$��1��$��Stretch=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Fecha��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *fecha+ �� StringFormat$ dd/MM/yyyy HH:mm��  $ Producto��$ *  �� *
producto+  $ Código��$ *  �� *codigo+  $ Costo Unitario��$ *  �� *costoUnitario+  $ Tipo de Movimiento��$ *  �� *descripcion+  $   ��$
 auto  �� *tmovimiento+   ElementStyle ��  �� 
TargetType" �� �� Triggers P�  P� Property � �� P� Value$ Entrada��. ���  �� Property � �� �� Value
 ����P�  � ��$ Salida��. ���  � ��
 ��İ�  $ Cantidad��$ *  �� *
cantidad+  $ Total��$ *  �� *total+  $ Total $��$ *  �� *tPagar+�� $��2��$��Right=�$��Center=�$��	10,0,10,0q�$ 
Horizontal=�.+��� $��TOTAL: ��$��20(��� -   $ lbl_totalSuma��$��20(��� $��4��$��10q�$��Right=�	Ver en �� $2��,https://github.com/ruffles182/repProov_llita?�.�
GitHub.com