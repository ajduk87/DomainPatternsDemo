
using CommercialApplication.DomainLayer.Entities.ValueObjects.Common;
using System;

namespace CommercialApplicationCommand.DomainLayer.Entities.OrderEntities
{
    public class Order : Entity
    {
        public State State { get; set; }
        public CreationDate CreationDate { get; set; }

        public Order()
        {
            this.State = new State("Open");
            this.CreationDate = new CreationDate(DateTime.Now.ToShortDateString());
        }

        public Order SetState(State newState)
        {
            if (newState.Equals("open"))
            {
                if (this.State.Equals("closed"))
                {
                    //stay in closed state
                    this.State = new State("closed");
                }
                if (this.State.Equals("closedandempty"))
                {
                    //stay in closedandempty state
                    this.State = new State("closedandempty");
                }
                if (this.State.Equals("open"))
                {
                    //stay in open state
                    this.State = new State("open");
                }
                if (this.State.Equals("paused"))
                {
                    //transit to open state
                    this.State = new State("open");
                }
            }
            else if (newState.Equals("paused"))
            {
                if (this.State.Equals("closed"))
                {
                    //stay in closed state
                    this.State = new State("closed");
                }
                if (this.State.Equals("closedandempty"))
                {
                    //stay in closedandempty state
                    this.State = new State("closedandempty");
                }
                if (this.State.Equals("open"))
                {
                    //transit to paused state
                    this.State = new State("paused");
                }
                if (this.State.Equals("paused"))
                {
                    //stay in paused state
                    this.State = new State("paused");
                }
            }
            else if (newState.Equals("closed"))
            {
                if (this.State.Equals("closed"))
                {
                    //stay in closed state
                    this.State = new State("closed");
                }
                if (this.State.Equals("closedandempty"))
                {
                    //stay in closedandempty state
                    this.State = new State("closedandempty");
                }
                if (this.State.Equals("open"))
                {
                    //transit to closed state
                    this.State = new State("closed");
                }
                if (this.State.Equals("paused"))
                {
                    //stay in paused state
                    this.State = new State("paused");
                }
            }
            else if (newState.Equals("closedandempty"))
            {
                if (this.State.Equals("closed"))
                {
                    //stay in closed state
                    this.State = new State("closed");
                }
                if (this.State.Equals("closedandempty"))
                {
                    //stay in closedandempty state
                    this.State = new State("closedandempty");
                }
                if (this.State.Equals("open"))
                {
                    //transit to closedandempty state
                    this.State = new State("closedandempty");
                }
                if (this.State.Equals("paused"))
                {
                    //stay in paused state
                    this.State = new State("paused");
                }                
            }
            return this;
        }
    }
}