   M S B A M L   `   `   `  ����H  DBookie, Version=15196.2017.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Bookie.ConvertersBookie.Converters  5          Bookie.Views.LogWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls  5      0
convertersclr-namespace:Bookie.Converters  5      -   5           AccentColorBrush#���   5      $��1q�5      (  "MahApps.Metro.Controls.MetroWindow    EnableDWMDropShadow  .    WindowTransitionsEnabled .   � Title$	 Log��5
       � WindowStartupLocation$ CenterScreen=�6#   $	��650��6H   $	��300��6W    � 	Resources 5      /   )Bookie.Converters.BoolVisibilityConverter  BoolVisibilityConverter��%   &	         5   
   6-   5      .��5      � .+�5   
   ]� ��. .+�5      � $	��Top=�6   $��Stretch=�6(   $��50��6F   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ 	LightGray��6'    � Offset$ 0Q�69   � 5      $ White��6'   $ 1Q�65   5      .+�5      �� 	 �� Orientation$	 
Horizontal=�6   $
��Left=�66   .+�5      �� $��15,0,5,0q�6C   $��Delete Logs��6U   $��23��6k   $��Center=�5      $��Center=�6:   ��5      �� *DeleteLogsCommand+5   :   �� 5      -   5        $��Refresh��5   2   $��5q�6D   $��23��6O   $��Center=�6[   $��Center=�5      5      ]� 5      $��Right=�6   $��Center=�68   .+�5      	� $��5q�6"   $��Center=�6-   
 	� 	GroupName$
 Filter��6H   $	��All��6[    d� 	IsChecked 5    "   �� *
FilterNone+	� 5!      $��5q�5"   "   $��Center=�6-   $
 Filter��6H   $��DEBUG��6[   y�5!   "   �� *	DebugMode+ �� 	Converter# [  5#   "   �� *FilterDebug+	� 5$      $��5q�6"   $��Center=�6-   $
 Filter��6H   $
��INFO��6[    5%   "   �� *
FilterInfo+	� 5&      $��5q�6"   $��Center=�6-   $
 Filter��6H   $��ERROR��6[    5'   "   �� *FilterError+	� 5(      $��5q�6"   $��Center=�6-   $
 Filter��6H   $��FATAL��6[    5)   "   �� *FilterFatal+(  "System.Windows.Controls.DatePicker  5+      -   5        $��
datePicker��5+   !   
������ $	��150��5,   !   $��Right=�6-   $��10,0,5,0q�6P   $��Center=�5-   !      SelectedDate 5+   L   �� *
FilterDate+5-   !   �� 5.      -   5        $��Clear��5.   4   $��5q�6D   $��23��6O   $��Center=�6[   $��Center=�5/      50      51      &   System.Windows.Controls.DataGrid  56      $��Stretch=�6   $��Stretch=�65      
IsReadOnly .    AutoGenerateColumns .  ��6Q   �� *Log+   Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6)      Header$
 Date��66   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   �� *Date+  5:      $
 Auto 6)   $ Thread��66    6F   �� *Thread+  5;      $
 Auto 6)   $ Level��66    6E   �� *Level+  5<      $ * 6)   $ Message��63    6D   �� *	Message+  5=      $ * 6)   $ 	Exception��63    6F   �� *	Exception+5@      5A      5B      5C      