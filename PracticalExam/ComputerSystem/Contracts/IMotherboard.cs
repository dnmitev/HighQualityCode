namespace ComputerSystem.Contracts
{
    /// <summary>
    /// This interface gives the main logic of the motherboard available actions. It acts as a mediator and is 
    /// used in the Mediator Pattern. The motherboard knows about the RAM and Video card objects and works with
    /// them where used.
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Stores the randomly CPU generated integer to the "Ram" object
        /// </summary>
        /// <param name="number">32bit signed integer</param>
        void SaveToRam(int number);

        /// <summary>
        /// Loads an integer from the "Ram" object
        /// </summary>
        /// <returns>the randomly generated from the CPU integer number</returns>
        int LoadFromRam();

        /// <summary>
        /// Makes the VideoCard object visualize the given text as a string
        /// </summary>
        /// <param name="text">string parameter to be visualized</param>
        void Draw(string text);
    }
}