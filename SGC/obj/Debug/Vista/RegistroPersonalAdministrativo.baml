   M S B A M L   `   `   `  ����>  :SGC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SGC.Vista	SGC.Vista  5   	   .    (SGC.Vista.RegistroPersonalAdministrativo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SGC.Vista     5   	     � Title$)  #Registro de Personal Administrativo��5   	   $	��450��65   $	��800��6B    � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Elementos/Estilos.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� ImageSource$$ /Elementos/Imagenes/uvlogo.png��6    �� Opacity$	 0.3Q�5       j� Stretch$ Uniform=�5       j� TileMode$
 None=�5       j� Viewport$ 0.2,0.2,0.6,0.6�5      	 j� ViewportUnits$	 RelativeToBoundingBox=�5      .+�5   
   (� .��5      � $	��549��6   
 � RowDefinitions
 5      �� 5      $
��Auto �6$   �� 5       $
��Auto �6$   �� 5!      $
��Auto �6$   �� 5"      $
��Auto �6$   �� 5#      $
��Auto �6$   �� 5$      $
��Auto �6$   �� 5%      $
��Auto �6$   �� 5&      $
��Auto �6$   �� 5'      $��* �6$   �� 5(      $
��Auto �6$    � ColumnDefinitions 5*      �� 5+      $
��Auto �6'   �� 5,      $��* �6'   .+�5/      ��  �� Orientation$ 
Horizontal=�6   $��0��66   $��2��6C   $��Center=�6W   $��0,0,0,0q�6t   .+�50      �� $)��#Registro de Personal Administrativo��6    $��30(�51       $
��Bold"�6.   ���#006C34$��Center=�53       54      �� 56      $��Nombre:��6   $��1��6+   $��0��68      TextBlockStyle#��[  6H   �� 57      -   5         ��Name$ NombreTextBox��57      $��1��61   $��1��6>   $��5q�6N   �� 59      $��
Apellidos:��6   $��2��6.   $��0��6;   $��Center=�6K   $��5q�6f   #��[  6q   �� 5:      -   5        $ ApellidosTextBox��5:      $��2��64   $��1��6A   $��5q�6Q   �� 5<      $��Correo:��6   $��3��6+   $��0��68   $��Center=�6H   $��5q�6c   #��[  6n   �� 5=      -   5        $ CorreoTextBox��5=      $��3��61   $��1��6>   $��5q�6N   �� 5?      $��Nombre de Usuario:��6   $��4��66   $��0��6C   $��Center=�6S   $��5q�6n   #��[  6y   �� 5@      -   5        $ NombreUsuarioTextBox��5@      $��4��68   $��1��6E   $��5q�6U   �� 5B      $��Contraseña:��6   $��5��6/   $��0��6<   $��Center=�6L   $��5q�6g   #��[  6r   G� 5C      -   5         G�Name$ ContrasenaPasswordBox��5C      $��5��6=   $��1��6J   $��5q�6Z   �� 5E      $
��RFC:��6   $��6��6(   $��0��65   $��Center=�6E   $��5q�6`   #��[  6k   �� 5F      -   5        $ 
RfcTextBox��5F      $��6��6.   $��1��6;   $��5q�6K   �� 5H      $��Sede:��6   $��7��6)   $��0��66   $��Center=�6F   $��5q�6a   #��[  6l   �� 5I      -   5        $ SedeTextBox��5I      $��7��6/   $��1��6<   $��5q�6L   �� 5K      $��Número de Personal��6   $��8��66   $��0��6C   $	��Top=�6S   $��5,0,5,0q�6k   #��[  6|   �� 5L      -   5        $ NumeroPersonalTextBox��5L      $��8��69   $��1��6F   $��5,5,5,50q�6V   $��2��6h   �� 5N      $��9��6   $��2��6*   $ 
Horizontal=�6>   $��Right=�6W   $��5q�6s   .+�5O      �� -	   5         ��Name$ RegistrarButton��5O      $��	Registrar��66   $	��100��6J   $��5q�6V     RoundedButtonStyle#��[ 6a   6�   �� 5P      -
   5        $ CancelarButton��5P      $��Cancelar��65   $	��100��6H   $��5q�6T   #��[ 6_   ���#C22A2A6�   5Q      5R      5S      5T      5U      