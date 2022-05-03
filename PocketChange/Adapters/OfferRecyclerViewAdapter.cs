using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace PocketChange.Adapters
{
    class OfferRecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<OfferRecyclerViewAdapterClickEventArgs> ItemClick;
        public event EventHandler<OfferRecyclerViewAdapterClickEventArgs> ItemLongClick;
        string[] items;

        public OfferRecyclerViewAdapter(string[] data)
        {
            items = data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            //var id = Resource.Layout.__YOUR_ITEM_HERE;
            //itemView = LayoutInflater.From(parent.Context).
            //       Inflate(id, parent, false);
            
            var vh = new OfferRecyclerViewAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as OfferRecyclerViewAdapterViewHolder;
            //holder.TextView.Text = items[position];
        }

        public override int ItemCount => items.Length;


        void OnClick(OfferRecyclerViewAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(OfferRecyclerViewAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }


    public class OfferRecyclerViewAdapterViewHolder : RecyclerView.ViewHolder
    {
        //public TextView TextView { get; set; }


        public OfferRecyclerViewAdapterViewHolder(View itemView, Action<OfferRecyclerViewAdapterClickEventArgs> clickListener,
                            Action<OfferRecyclerViewAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            //TextView = v;
            itemView.Click += (sender, e) => clickListener(new OfferRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new OfferRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
       
    }

    public class OfferRecyclerViewAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}