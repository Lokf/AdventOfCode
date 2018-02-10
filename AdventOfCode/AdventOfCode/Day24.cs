using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day24
    {
        public static int Task1(string[] components)
        {
            var parsedComponents = components
                .Select(ParseComponent)
                .ToList();

            var bridge = new Bridge();

            return BridgeBuilder.BuildStrong(bridge, parsedComponents);
        }

        public static int Task2(string[] components)
        {
            var parsedComponents = components
               .Select(ParseComponent)
               .ToList();

            var bridge = new Bridge();

            return BridgeBuilder.BuildLong(bridge, parsedComponents).strength;
        }

        private static Component ParseComponent(string component)
        {
            var pins = component
                .Split('/')
                .Select(int.Parse)
                .ToArray();

            return new Component(pins[0], pins[1]);
        }

        private class Component
        {
            public int PinA { get; }

            public int PinB { get; }

            public int Strength => PinA + PinB;

            public Component(int pinA, int pinB)
            {
                PinA = pinA;
                PinB = pinB;
            }
            
            public bool CanConnectTo(int pin)
            {
                return pin == PinA || pin == PinB;
            }
        }

        private class BridgeBuilder
        {
            public static int BuildStrong(Bridge bridge, List<Component> components)
            {
                var bestBridge = bridge.Strength;

                var connectingComponents = components.Where(component => component.CanConnectTo(bridge.DanglingPin));                
                foreach (var component in connectingComponents)
                {
                    var longerBridge = new Bridge(bridge, component);
                    var remainingComponents = new List<Component>(components.Where(c => c != component));
                    var strength = BuildStrong(longerBridge, remainingComponents);
                    bestBridge = Math.Max(bestBridge, strength);
                }

                return bestBridge;
            }

            public static (int length, int strength) BuildLong(Bridge bridge, List<Component> components)
            {
                var bestBridge = (bridge.Length, bridge.Strength);

                var connectingComponents = components.Where(component => component.CanConnectTo(bridge.DanglingPin));
                foreach (var component in connectingComponents)
                {
                    var longerBridge = new Bridge(bridge, component);
                    var remainingComponents = new List<Component>(components.Where(c => c != component));
                    var (length, strength) = BuildLong(longerBridge, remainingComponents);
                    if (length > bestBridge.Length)
                    {
                        bestBridge = (length, strength);
                    }
                    else if (length == bestBridge.Length)
                    {
                        bestBridge = (length, Math.Max(bestBridge.Strength, strength));
                    }
                }

                return bestBridge;
            }
        }

        private class Bridge
        {     
            public int DanglingPin { get; }
            public int Strength { get; }
            public int Length { get; }

            public Bridge()
            {
                DanglingPin = 0;
                Strength = 0;
                Length = 0;
            }

            public Bridge(Bridge bridge, Component component)
            {
                if (component.PinA == bridge.DanglingPin)
                {
                    DanglingPin = component.PinB;
                }
                else if (component.PinB == bridge.DanglingPin)
                {
                    DanglingPin = component.PinA;
                }
                else
                {
                    throw new ArgumentException(nameof(component));
                }

                Strength = bridge.Strength + component.Strength;
                Length = bridge.Length + 1;
            }
        }
    }
}
