using BancoCSharp.View;
int op;

do
{
    Tela.Principal();

    try
    {
        op = int.Parse(Console.ReadLine());    
    }
    catch (FormatException)
    {
        op = -1;        
    }

    switch (op)
    {
        case -1:
            Console.WriteLine("As opções devem ser selecionadas por números");
            Console.WriteLine("Pressione qualquer tecla ...");
            Console.ReadKey();
            break;
        case 0:
            break;
        case 1:
            try
            {
                Tela.CadastraContaCorrente();    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla ...");
                Console.ReadKey();
            }
            
            break;
        case 2:
            try
            {
                Tela.CadastraContaPoupanca();    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla ...");
                Console.ReadKey();
            }

            break;
        case 3:
            try
            {
                Tela.CadastraContaInvestimento();    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla ...");
                Console.ReadKey();
            }
            
            break;
        case 4:
            try
            {
                Tela.ImprimirExtrato();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
                
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla ...");
                Console.ReadKey();
            }

            break;
        case 5:
            try
            {
                Tela.Depositar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla ...");
                Console.ReadKey();
            }
            
            break;
        case 6:
            try
            {
                Tela.Sacar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla ...");
                Console.ReadKey();
            }
            break;
        case 7:
            try
            {
                Tela.Transferir();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla ...");
                Console.ReadKey();
            }
            
            break;
        case 8:
            try
            {
                Tela.ListarContas();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla ...");
                Console.ReadKey();
            }
            
            break;    
        default:
            Console.WriteLine("Opção inválida.");
            Console.WriteLine("Pressione qualquer tecla ...");
            Console.ReadKey();            
            break;
    }
} while (op != 0);

