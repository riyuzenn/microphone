<Window x:Class="Serum_Microphone.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:Serum_Microphone"
        mc:Ignorable="d" x:Name="mainWindow"
        Title="Serum Microphone" Height="496.345" Width="723.754"
        xmlns:ui="http://schemas.modernwpf.com/2019"
        ui:WindowHelper.UseModernWindowStyle="True"
        ui:ThemeManager.RequestedTheme="Dark"
        ui:TitleBar.ExtendViewIntoTitleBar="True"
        ui:TitleBar.Style="{DynamicResource AppTitleBarStyle}"
        ui:TitleBar.ButtonStyle="{DynamicResource AppTitleBarButtonStyle}"
        Background="{DynamicResource SystemControlPageBackgroundChromeMediumLowBrush}"
        WindowStartupLocation="CenterScreen" Loaded="Window_Loaded" Icon="pack://application:,,,/Assets/microphone.ico">

    <Window.Resources>

        <Style x:Key="AppTitleBarStyle" TargetType="ui:TitleBarControl">
            <Setter Property="ui:ThemeManager.RequestedTheme" Value="Dark" />
        </Style>
        <Style x:Key="AppTitleBarButtonStyle" TargetType="ui:TitleBarButton">
            <Setter Property="IsActive" Value="{Binding IsActive, ElementName=Window}" />
        </Style>
        <Style x:Key="AppTitleBarBackButtonStyle" TargetType="ui:TitleBarButton" BasedOn="{StaticResource TitleBarBackButtonStyle}">
            <Setter Property="IsActive" Value="{Binding IsActive, ElementName=Window}" />
        </Style>
    </Window.Resources>

    <Grid>
        <Grid.ColumnDefinitions>
            
        </Grid.ColumnDefinitions>
        <Grid
            x:Name="AppTitleBar"
            Background="#121212"
            Height="{Binding ElementName=Window, Path=(ui:TitleBar.Height)}"
            ui:ThemeManager.RequestedTheme="Dark" Grid.ColumnSpan="2">

            <Grid.Style>
                <Style TargetType="Grid">
                    <Setter Property="TextElement.Foreground" Value="{DynamicResource SystemControlForegroundBaseHighBrush}" />
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding IsActive, ElementName=Window}" Value="False">
                            <Setter Property="TextElement.Foreground" Value="{DynamicResource SystemControlDisabledBaseMediumLowBrush}" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Grid.Style>

            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="254*" />
                <ColumnDefinition Width="Auto" />
                <ColumnDefinition Width="253*" />
                <ColumnDefinition Width="Auto" />
                <ColumnDefinition Width="94*" />
                <ColumnDefinition Width="159*"/>
            </Grid.ColumnDefinitions>



            <!-- Horizontally centered title -->
            
            <StackPanel
                Grid.Column="3"
                Orientation="Horizontal">
                <ui:TitleBarButton
                    Style="{StaticResource AppTitleBarButtonStyle}"
                    FontFamily="{DynamicResource ContentControlThemeFontFamily}"
                    FontSize="13"
                    Width="NaN"
                    Padding="16,0"
                    />

            </StackPanel>



        </Grid>
            <ui:NavigationView 
                PaneDisplayMode="LeftCompact"
                IsBackButtonVisible="Collapsed"
                SelectionChanged="NavigationView_SelectionChanged"
                Loaded="NavigationView_Loaded"
                IsSettingsVisible="True">

                <ui:NavigationView.MenuItems>
                    <ui:NavigationViewItem Content="Player" Icon="Microphone" Tag="playerview"/>

                    <ui:NavigationViewItem Content="About" Icon="Contact" Tag="aboutview"/>
                </ui:NavigationView.MenuItems>
                <ScrollViewer>
                    <ui:Frame x:Name="ContentFrame" />
                </ScrollViewer>
            </ui:NavigationView>

    </Grid>

</Window>
