   M S B A M L   `   `   `  ����  SGC    SGC.Vista.RegistroDocente   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Registrar Docente��5   	   $	��700��6#   $	��850��60    � 	Resources 5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $ /Elementos/Estilos.xaml?�6%   %    5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��Registrar Docente��6   $��30(�5      $
��Bold"�6"      UVPrimaryColor#��[  5      $��0��5      $��2��6!   $��Center=�5       $��0,0,0,20q�61   �� 5"   
   $��1��6   $��0��6"   $��10q�62   .+�5#      �� $��Nombre:��6     TextBlockStyle#��[ 6'   �� 5$      -   5         ��Name$ NombreTextBox��5$        RoundedTextBoxStyle#��[ 6-   �� 5%      -   5         ��Name$ ErrorNombreTextBlock��5%      
���  ��$��12(�6G   $��5,0,0,10q�6U   �� 5'      $��Número de Personal:��6   #��[ 63   �� 5(      -   5        $ NumeroPersonalTextBox��5(      #��[ 65   �� 5)      -   5        $" ErrorNumeroPersonalTextBlock��5)      
���  ��$��12(�6O   $��5,0,0,10q�6]   �� 5+      $��Correo:��6   #��[ 6'   �� 5,      -   5        $ CorreoTextBox��5,      #��[ 6-   �� 5-      -   5        $ ErrorCorreoTextBlock��5-      
���  ��$��12(�6G   $��5,0,0,10q�6U   �� 5/      $��Contratación:��6   #��[ 6-   �� 50      -   5         ��Name$ ContratacionComboBox��50      .@�51      �� $��Planta��6   �� 52      $��Interino por plaza��6   �� 53      $��Interino por persona��6   �� 54      $&�� Interino por tiempo determinadoo��6   �� 55      $��Suplente o sustituto��6   56      �� 57      -   5        $  ErrorContratacionTextBlock��57      
���  ��$��12(�6M   $��5,0,0,10q�6[   58      �� 5:   
   $��1��6   $��1��6"   $��10q�62   .+�5;      �� $��
Apellidos:��6   #��[ 6*   �� 5<      -	   5        $ ApellidosTextBox��5<      #��[ 60   �� 5=      -
   5        $ ErrorApellidosTextBlock��5=      
���  ��$��12(�6J   $��5,0,0,10q�6X   �� 5?      $��Nombre de Usuario:��6   #��[ 62   �� 5@      -   5        $ NombreUsuarioTextBox��5@      #��[ 64   �� 5A      -   5        $! ErrorNombreUsuarioTextBlock��5A      
���  ��$��12(�6N   $��5,0,0,10q�6\   �� 5C      $��Contraseña:��6   #��[ 6+   G� 5D      -   5        	 G�Name$	 ContrasenaPasswordBox��5D        RoundedPasswordBoxStyle#��[ 69   �� 5E      -   5        $ ErrorContrasenaTextBlock��5E      
���  ��$��12(�6K   $��5,0,0,10q�6Y   �� 5G      $��Categoría:��6   #��[ 6*   �� 5H      -   5        $ CategoriaComboBox��5H      .@�5I      �� $��Rector��6   �� 5J      $ ��Coordinador de laboratorio��6   �� 5K      $��Jefe de carrera��6   �� 5L      $��Auxiliar técnico��6   �� 5M      $��Eventual��6   5N      �� 5O      -   5        $ ErrorCategoriaTextBlock��5O      
���  ��$��12(�6J   $��5,0,0,10q�6X   �� 5Q      $��Sede:��6   #��[ 6%   �� 5R      -   5        $ SedeTextBox��5R      #��[ 6+   �� 5S      -   5        $ ErrorSedeTextBlock��5S      
���  ��$��12(�6E   $��5,0,0,10q�6S   5T      �� 5V   
   $��2��6   $��2��6"   
 �� Orientation$
 
Horizontal=�66   $��Center=�6O   $��0,20,0,0q�6l   .+�5W      �� -   5         ��Name$ RegistrarButton��5W      $��	Registrar��6.     RoundedButtonStyle#��[ 6B   $	��120��6n   $��0,0,20,0q�6z   6�   �� 5X      -   5        $ CancelarButton��5X      $��Cancelar��6-   #��[ 6@     UVErrorColor#��[ 6l   $	��120��6�   $��20,0,0,0q�6�   6�   5Y      5Z      5[      