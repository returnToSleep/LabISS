
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server{
    /**
     * 
     */
    public interface Repository<T> {


        /**
         * @return
         */
        T findOne();

        /**
         * @return
         */
        T findAll();

        /**
         * @param T elem 
         * @return
         */
        void save(T elem);

        /**
         * @param T elem 
         * @return
         */
        void delete(T elem);

        /**
         * @param T elem 
         * @return
         */
        void update(T elem);

    }
}