
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server{
    /**
     * 
     */
    public interface Repository {


        /**
         * @return
         */
        public T findOne();

        /**
         * @return
         */
        public T findAll();

        /**
         * @param T elem 
         * @return
         */
        public void save(void T elem);

        /**
         * @param T elem 
         * @return
         */
        public void delete(void T elem);

        /**
         * @param T elem 
         * @return
         */
        public void update(void T elem);

    }
}