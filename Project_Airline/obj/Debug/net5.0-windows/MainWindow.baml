   M S B A M L   `   `   `  ����J  FProject_Airline, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Project_AirlineProject_Airline  5   	        Project_Airline.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Project_Airline     5   	   
�������  � Title$  
MainWindow��5   	   $	��594��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��106* �6   �� 5      $	��55* �6   .+�5   
   � $��0��6   $��	10,0,0,38q�6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��AirlineDataGrid��5   F      AutoGenerateColumns$ False��6   $��5,5,5,40q�64      
IsReadOnly$
 True��6]    � 	Resources 5      )  #System.Windows.Controls.DataGridRow �� 
TargetType��%E   '        �� 5      "  6   .�5      -   5        5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Name+  5      $ Email��6)    68   �� *Email+  5      $ Phone��6)    68   �� *Phone+  5      $ Website��6)    6:   �� *	Website+  5      $
 Logo��6)   	   
Visibility$	 Hidden=�6P    67   �� *Logo+6P   4  .System.Windows.Controls.DataGridTemplateColumn  5       
   CellTemplate
 5!      �� 5"      .R�5#   "   �� $��40��6@   $��40��6L   ��6(   �� *Logo+6L   5$      5&        5(      
 5)      �� 5*      .R�5+   "   �� -   5        $��Update��5+   )   6:   5,      5.        50      
 51      �� 52      .R�53   "   �� -   5        $��Delete��53   )   6:   54      56      5:      �� 5;      
���   �$��1q�6)   $��5,5,5,40q�6=   ._�5<      �� $��0,329,458,-277q�6   $��Right=�65   $	��289��6Q   .+�5=      �� $��Edit the item��6   $��Center=�64   $��Center=�6Q   � 5>      -   5         �Name$ UpdateAirlineGrid��5>      $��5q�66    � ColumnDefinitions 5?      �� 5@      �� 5A       5C      �� 5D      �� 5E      �� 5F      �� 5G      �� 5H      �� 5I      �� 5J      .+�5O      �� $��0��6    $��0��6-   $
��Name��6=   �� 5P      $��0��6"   $��1��6/   ��6?   �� *Name+�� 5R      $��1��6    $��0��6-   $��Email��6=   �� 5S      $��1��6"   $��1��6/   ��6?   �� *Email+�� 5U      $��2��6    $��0��6-   $��Website��6=   �� 5V      $��2��6"   $��1��6/   ��6?   �� *	Website+�� 5X      $��3��6    $��0��6-   $��Phone Number��6=   �� 5Y      $��3��6"   $��1��6/   ��6?   �� *Phone+�� 5[      $��4��6    $��0��6-   $
��Logo��6=   �� 5\      -   5        $��Upload��5\   !   $��4��62   $��1��6?   $��0,0,0,10q�6e   $��2��6w   �� 5_      -   5        $��2��5_   !   $��5��65   $
��Edit��6B   6Q   5`      5a      5c      5d      � 5e   
   $��355,2,345,107q�6   $��1��6&    5f      �� 5g      $
��100* �6#   �� 5h      $	��31* �6#    5j      �� 5k      $	��22* �6    �� 5l      $��5* �6    .+�5n      �� -   5        $��Add New Item+��5n      $��218,56,-304,-56q�6=    J� RenderTransformOrigin$ -0.128,-0.947&�6V   $��2��6|   $��1��6�   �� 5o      -	   5         ��Name$ MyImage1��5o      $��7,-18,-45,-54q�6&   $ -2.025,0.588&�6=   $��2��6b   $��2��6s   5p      5q      5t      