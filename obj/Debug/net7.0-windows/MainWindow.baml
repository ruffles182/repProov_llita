   M S B A M L   `   `   `  ����F  BREPORTE WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:REPORTE_WPFREPORTE_WPF  5   	       REPORTE_WPF.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:REPORTE_WPF     5   	     � Title$"  PDV - Reporte de Proveedores��5   	   $	��461��6.   $	��900��6;      AppIcon � Icon# [  5	   	   .��5      � -   5         �Name$ frm_main��5      $��0,0,0,0q�6   .+�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $��* �6#   .+�5      � $��50,25,50,10q�6   $��0��6(    5      �� 5      $
��Auto �6'   �� 5      $��* �6'   .+�5      �� -   5         ��Name$ lbl_proveedores��5      $��Poveedores:��5      $
��Left=�5       $	��Top=�5!      $��0��5"      �� 5%      -   5         ��Name$ cb_proveedores��5&      $	��Top=�5'       �� SelectedIndex$ 0��5)      $��1��5*      $��Stretch=�5+      ��5-      �� 5.      .R�5/      �� .+�50   "   �� ��6,   �� *nombre+6G   51      52      54      55      �� 56       �� Orientation$ 
Horizontal=�6   $��50,10,20,10q�62   $��1��6G   $��Center=�6T   .+�57      �� -   5        $ 	lbl_desde��58      $��Desde��59      $��Center=�5:      $��
0,0, 30, 0q�5;      (  "System.Windows.Controls.DatePicker  5=      -   5        	  Name$	 dp_desde��5>      $��Center=�5?      $��0,0,50,0q�5@      5A      �� 5C      -   5        $ 	lbl_hasta��5D      $��Hasta��5E      $��0,0,30,0q�6%   $��Center=�5F        5H      -   5        $	 dp_hasta��5I      $��Center=�5J      $��0,0,50,0q�5K      5L      5N      �� 5O      -   5        
 ��Name$
 
cb_filtrar��5P      $��Filtrar por fecha��5Q      $��Center=�5R      $��0,0,0,0q�5S      $��2��5T      $��Center=�5U      5W      � 5]      $��0,0,0,0q�6   $��3��6$    5^      �� 5_      $
��Auto �6'   $	��200��64   �� 5`      .+�5b      � $��0��6    5c      �� 5d      $
��Auto �6(   �� 5e      $
��Auto �6(   �� 5f      $
��Auto �6(   �� 5g      $��* �6(   .+�5i      �� -	   5        $ 
lbl_buscar��5i      $ ��Buscar (Código o nombre):��60   $��0��6T   $��
10, 10,0,0q�6a   �� 5j      -
   5         ��Name$ tb_buscarProd��5k      $��1��5l      $��Stretch=�5m      $��	10,0,10,0q�5n       �� TextWrapping$
 Wrap=�5o      $	��Top=�5p      $
��Auto��5q      $��16(�5r   A   �� 5t      $��
Productos:��6   $��2��61   $��	10,0,10,0q�6>   �� 5u      -   5         ��Name$ lb_prod_proov��5u      $��Stretch=�65   $��Stretch=�6Q   $��
10,0,10,10q�6o   $��3��6�   ��5v      �� 5w      .R�5x   "   �  5y   &   �� 5z   *   $��* �6;   6H   .+�5}   &   �� $��0��60   ��6@   �� *nombre+6Z   5~   #   5      5�      5�      � 5�      $��1��6    5�      �� 5�      $
��Auto �6(   �� 5�      $��* �6(   �� 5�      $
��Auto �6(   .+�5�      �� -   5        $ 
lbl_header��5�      $��Historial de Movimientos��60   $��0��6S   $��10,10,10, 0q�6`   $��16(�6u   &   System.Windows.Controls.DataGrid  5�      -   5          Name$ dg_historial��5�      $��	10,0,10,0q�65   $��1��6H   $��Stretch=�6U      Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Fecha��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6@   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *fecha+ �� StringFormat$ dd/MM/yyyy HH:mm��  5�      $ Producto��61   $ * 6C    6M   �� *
producto+  5�      $ Código��61   $ * 6A    6K   �� *codigo+  5�      $ Costo Unitario��61   $ * 6I    6S   �� *costoUnitario+  5�      $ Tipo de Movimiento��61   $ * 6M    6W   �� *descripcion+  5�      $   ��61   $
 auto 6]    6=   �� *tmovimiento+   ElementStyle 5�   "   �� 5�   &    �� 
TargetType" ��6,    �� Triggers 5�   *   P� 5�   .    P� Property � �� P� Value$ Entrada��6F   . �5�   2   ��  �� Property � �� �� Value
 ����6O   5�   /   P� 5�   .    � ��$ Salida��6F   . �5�   2   ��  � ��
 ��İ�6O   5�   /   5�   '   5�        5�      $ Cantidad��61   $ * 6C    6M   �� *
cantidad+  5�      $ Total��61   $ * 6@    6J   �� *total+  5�      $ Total $��61   $ * 6B    6L   �� *tPagar+5�      �� 5�      $��2��6!   $��Right=�6.   $��Center=�6J   $��	10,0,10,0q�6e   $ 
Horizontal=�6x   .+�5�      �� $��TOTAL: ��6    $��20(�62   �� 5�      -   5        $ lbl_totalSuma��5�       $��20(�67   5�      5�      5�      �� 5�      $��4��6   $��10q�6%   $��Right=�61   	Ver en �� 5�      $2��,https://github.com/ruffles182/repProov_llita?�6#   .�6_   
GitHub.com6k   5�      5�      5�      5�      